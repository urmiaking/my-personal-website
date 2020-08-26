using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Areas.Admin.Models;
using PersonalWebsite.Data;
using PersonalWebsite.Utilities;

namespace PersonalWebsite.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _db;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IViewRenderService _viewRenderService;

        public LoginService(AppDbContext db, IHttpContextAccessor httpContext, IViewRenderService viewRenderService)
        {
            _db = db;
            _httpContext = httpContext;
            _viewRenderService = viewRenderService;
        }


        public async Task<bool> LoginAsync(LoginViewModel loginForm)
        {
            var isFound = await _db.SiteAdmins.AnyAsync(a =>
                a.Email.Equals(loginForm.Email)
                && a.Password.Equals(PasswordHelper.Hash(loginForm.Password)));

            if (!isFound)
            {
                return false;
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, loginForm.Email)
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties()
            {
                IsPersistent = loginForm.RememberMe,
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(43200)
            };

            await _httpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity), authProperties);

            return true;

        }

        public async Task LogoutAsync()
        {
            await _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> ValidateEmailAsync(string email)
        {
            return await _db.SiteAdmins.AnyAsync(a => a.Email.Equals(email));
        }

        public async Task<bool> SendResetPasswordAsync(string email)
        {
            try
            {
                var admin = await _db.SiteAdmins.FirstOrDefaultAsync(a => a.Email.Equals(email));

                admin.ResetPasswordCode = Generator.GenerationUniqueName();

                await UpdateUserAsync(admin);

                var forgetPasswordViewModel = new ForgetPasswordTemplateViewModel()
                {
                    Name = admin.FullName,
                    Url = string.Concat(_httpContext.HttpContext.Request.Scheme, "://", 
                        _httpContext.HttpContext.Request.Host.ToUriComponent(),
                        $"/ResetPassword/{admin.ResetPasswordCode}")
                };

                var mail = new Email()
                {
                    To = email,
                    Subject = "بازیابی کلمه عبور - وبسایت شخصی",
                    Body = await _viewRenderService.RenderToStringAsync("_ForgetPasswordTemplate", forgetPasswordViewModel)
                };

                return await SendEmailAsync(mail); ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }

        public async Task UpdateUserAsync(SiteAdmin siteAdmin)
        {
            _db.Update(siteAdmin);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> SendEmailAsync(Email email)
        {
            var mailServer = await _db.MailServers.FindAsync(1);

            var mail = new MailMessage();
            var smtpServer = new SmtpClient(mailServer.HostAddress);
            mail.From = new MailAddress(mailServer.ServerAddress);
            mail.To.Add(email.To);
            mail.Subject = email.Subject;
            mail.Body = email.Body;
            mail.IsBodyHtml = true;

            smtpServer.Port = mailServer.Port;
            smtpServer.Credentials = new System.Net.NetworkCredential(mailServer.ServerAddress, mailServer.Password);
            smtpServer.EnableSsl = true;

            try
            {
                smtpServer.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public async Task<SiteAdmin> GetAdminByResetPasswordCodeAsync(string resetCode) =>
            await _db.SiteAdmins.FirstOrDefaultAsync(a => a.ResetPasswordCode.Equals(resetCode));

        public async Task<bool> ResetPasswordAsync(ResetPasswordViewModel resetPasswordForm)
        {
            var admin = await _db.SiteAdmins.FirstOrDefaultAsync(a =>
                a.ResetPasswordCode.Equals(resetPasswordForm.ResetCode));

            if (admin == null)
            {
                return false;
            }

            admin.ResetPasswordCode = Generator.GenerationUniqueName();
            admin.Password = PasswordHelper.Hash(resetPasswordForm.Password);

            await UpdateUserAsync(admin);

            return true;
        }
    }
}
