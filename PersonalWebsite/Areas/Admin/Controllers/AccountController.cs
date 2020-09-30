using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Services;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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

            TempData["Success"] = "مدیر عزیر، خوش آمدید!";

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
    }
}
