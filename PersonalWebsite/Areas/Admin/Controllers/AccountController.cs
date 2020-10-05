using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Data;
using PersonalWebsite.Services;
using PersonalWebsite.Utilities;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        private readonly AppDbContext _db;

        public AccountController(IAccountService accountService, AppDbContext appDbContext)
        {
            _accountService = accountService;
            _db = appDbContext;
        }

        #region Login

        [Route("[action]")]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginViewModel loginForm, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginForm);
            }

            var loginSucceed = await _accountService.LoginAsync(loginForm);

            if (!loginSucceed)
            {
                TempData["Error"] = "نام کاربری یا رمز عبور اشتباه است";
                return View(loginForm);
            }

            TempData["Success"] = "مدیر عزیز، خوش آمدید!";

            var decodedUrl = "";
            if (!string.IsNullOrEmpty(returnUrl))
                decodedUrl = WebUtility.UrlDecode(returnUrl);

            if (Url.IsLocalUrl(decodedUrl))
            {
                return Redirect(decodedUrl);
            }

            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        #endregion

        #region Logout

        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        #endregion

        #region ForgetPassword

        [Route("[action]")]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordForm)
        {
            if (!ModelState.IsValid)
            {
                return View(forgetPasswordForm);
            }

            var emailValidated = await _accountService.ValidateEmailAsync(forgetPasswordForm.Email);

            if (!emailValidated)
            {
                TempData["Error"] = "آدرس ایمیل وارد شده نامعتبر است";
                return RedirectToAction("Login");
            }

            var resetPasswordSent = await _accountService.SendResetPasswordAsync(forgetPasswordForm.Email);

            if (!resetPasswordSent)
            {
                TempData["Error"] = "مشکلی پیش آمد لطفا بعدا امتحان کنید";
                return RedirectToAction("Login");
            }

            TempData["Success"] = "لینک بازیابی رمز عبور به ایمیل شما ارسال شد!";
            return RedirectToAction("Login");
        }

        #endregion

        #region Reset Password

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> ResetPassword(string id)
        {
            var admin = await _accountService.GetAdminByResetPasswordCodeAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            var resetPasswordViewModel = new ResetPasswordViewModel()
            {
                ResetCode = id
            };

            return View(resetPasswordViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]/{id}")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordForm)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordForm);
            }

            var isPasswordReset = await _accountService.ResetPasswordAsync(resetPasswordForm);

            if (!isPasswordReset)
            {
                TempData["Error"] = "بازیابی رمز عبور با خطا مواجه شد";
                return RedirectToAction("Login");
            }

            TempData["Success"] = "رمز عبور شما با موفقیت تغییر یافت!";
            return RedirectToAction("Login");
        }

        #endregion

        #region Profile

        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _db.SiteAdmins
                .FirstOrDefaultAsync(a =>
                    a.Email.Equals(User.Identity.Name));

            var profileViewModel = new ChangeProfileViewModel
            {
                Email = user.Email
            };

            return View(profileViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> EditProfile(ChangeProfileViewModel changeProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(changeProfileViewModel);
            }

            var user = await _db.SiteAdmins.FirstOrDefaultAsync(a => a.Email.Equals(User.Identity.Name));

            user.Email = changeProfileViewModel.Email;

            if (!string.IsNullOrEmpty(changeProfileViewModel.CurrentPassword) && !string.IsNullOrEmpty(changeProfileViewModel.Password))
            {
                var currentPassword = PasswordHelper.Hash(changeProfileViewModel.CurrentPassword);
                if (user.Password.Equals(currentPassword))
                {
                    user.Password = PasswordHelper.Hash(changeProfileViewModel.Password);
                }
                else
                {
                    TempData["Error"] = "رمز عبور فعلی وارد شده صحیح نمی باشد";
                    return RedirectToAction("EditProfile");
                }
            }

            _db.SiteAdmins.Update(user);
            await _db.SaveChangesAsync();

            await _accountService.LogoutAsync();

            TempData["Success"] = "پروفایل شما با موفقیت ویرایش یافت. لطفا دوباره وارد شوید";
            return RedirectToAction("EditProfile");
        }

        #endregion
    }
}
