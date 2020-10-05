using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PersonalWebsite.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "صفحه مورد نظر شما یافت نشد";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "عدم پاسخگویی سرور. تیم فنی در حال بررسی مشکل است";
                    break;
            }
            return View("NotFound", statusCode);
        }
    }
}
