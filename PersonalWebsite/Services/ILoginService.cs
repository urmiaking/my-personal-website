using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Areas.Admin.Models;

namespace PersonalWebsite.Services
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(LoginViewModel loginForm);

        Task LogoutAsync();

        Task<bool> ValidateEmailAsync(string email);

        Task<bool> SendResetPasswordAsync(string email);

        Task UpdateUserAsync(SiteAdmin siteAdmin);

        Task<bool> SendEmailAsync(Email email);

        Task<SiteAdmin> GetAdminByResetPasswordCodeAsync(string resetCode);

        Task<bool> ResetPasswordAsync(ResetPasswordViewModel resetPasswordForm);
    }
}
