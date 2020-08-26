using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Services;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        #region Login

        [Route("[action]")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginViewModel loginForm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginForm);
            }

            var loginSucceed = await _loginService.LoginAsync(loginForm);

            if (!loginSucceed)
            {
                TempData["Error"] = "نام کاربری یا رمز عبور اشتباه است";
                return View(loginForm);
            }

            TempData["Success"] = "مدیر عزیر، خوش آمدید!";
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        #endregion

        #region Logout

        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _loginService.LogoutAsync();
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

            var emailValidated = await _loginService.ValidateEmailAsync(forgetPasswordForm.Email);

            if (!emailValidated)
            {
                TempData["Error"] = "آدرس ایمیل وارد شده نامعتبر است";
                return RedirectToAction("Login");
            }

            var resetPasswordSent = await _loginService.SendResetPasswordAsync(forgetPasswordForm.Email);

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
            var admin = await _loginService.GetAdminByResetPasswordCodeAsync(id);

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

            var isPasswordReset = await _loginService.ResetPasswordAsync(resetPasswordForm);

            if (!isPasswordReset)
            {
                TempData["Error"] = "بازیابی رمز عبور با خطا مواجه شد";
                return RedirectToAction("Login");
            }

            TempData["Success"] = "رمز عبور شما با موفقیت تغییر یافت!";
            return RedirectToAction("Login");
        }

        #endregion
    }
}
