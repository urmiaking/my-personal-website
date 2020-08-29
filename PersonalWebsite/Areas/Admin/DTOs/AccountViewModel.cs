using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.DTOs
{
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "{0} معتبر نیست")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} حداقل باید {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class ForgetPasswordViewModel
    {
        [Display(Name = "آدرس ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "{0} معتبر نیست")]
        public string Email { get; set; }
    }

    public class ForgetPasswordTemplateViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }

    public class ResetPasswordViewModel
    { 
        public string ResetCode { get; set; }

        [DisplayName("کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد")]
        public string Password { get; set; }

        [DisplayName("تکرار کلمه عبور جدید")]
        [Compare("Password", ErrorMessage = "{0} با {1} مطابقت ندارد")]
        public string RepeatPassword { get; set; }
    }
}
