using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Data;
using PersonalWebsite.Models.Weblog;
using PersonalWebsite.Services;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IPictureService _pictureService;

        public BlogController(AppDbContext db, IPictureService pictureService)
        {
            _db = db;
            _pictureService = pictureService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("[controller]/Add")]
        public IActionResult AddBlog() => View();

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddBlog(Blog blog, IFormFile imageFile, string categoryName)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            if (string.IsNullOrEmpty(categoryName))
            {
                ModelState.AddModelError("Category.Name", "لطفا دسته بندی بلاگ را مشخص کنید");
                return View(blog);
            }

            var category = await _db.BlogCategories.FirstOrDefaultAsync(a => a.Name.Equals(categoryName));

            if (category.Equals(null))
            {
                ModelState.AddModelError("Category.Name", "لطفا دسته بندی بلاگ را مشخص کنید");
                return View(blog);
            }

            var result = await _pictureService.SaveBlogImageAsync(imageFile);

            if (result.ImageName == null)
            {
                TempData["Error"] = "لطفا برای بلاگ خود عکسی انتخاب کنید";
                return View(blog);
            }

            if (result.SizeLimitReached)
            {
                TempData["Error"] = "حجم عکس بلاگ نباید بیشتر از 500 کیلوبایت باشد";
                return View(blog);
            }

            if (result.SavedSuccessfully)
            {
                blog.DateTime = DateTime.Now;
                blog.Author = "مسعود خدادادی";
                blog.CategoryId = category.Id;
                blog.ImageUrl = result.ImageName;

                await _db.Blogs.AddAsync(blog);
                await _db.SaveChangesAsync();
            }
            else
            {
                TempData["Error"] = "مشکلی در افزودن بلاگ به وجود آمد. لطفا دوباره امتحان کنید";
                return View(blog);
            }

            TempData["Success"] = "بلاگ با موفقیت افزوده شد";
            return RedirectToAction("Blogs");

        }

    }
}
