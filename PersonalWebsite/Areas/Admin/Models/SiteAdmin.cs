using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Areas.Admin.Models
{
    public class SiteAdmin
    {
        public int Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        public string ResetPasswordCode { get; set; }
    }
}
