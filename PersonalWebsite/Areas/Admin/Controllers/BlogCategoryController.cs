using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Data;
using PersonalWebsite.Models.Weblog;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly AppDbContext _db;

        public BlogCategoryController(AppDbContext db)
        {
            _db = db;
        }

        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            var blogCategoryViewModel = new BlogCategoryViewModel()
            {
                BlogCategories = await _db.BlogCategories.ToListAsync(),
                BlogCategory = new BlogCategory()
            };

            return View(blogCategoryViewModel);
        }

        [Route("[controller]/Add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BlogCategory blogCategory)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "نام دسته معتبر نمی باشد";
                return RedirectToAction("Index");
            }

            await _db.BlogCategories.AddAsync(blogCategory);
            await _db.SaveChangesAsync();

            TempData["Success"] = "دسته مورد نظر با موفقیت اضافه شد";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/Delete")]
        public async Task<IActionResult> Delete(int id = 0)
        {
            if (id == 0)
            {
                return StatusCode(404);
            }

            var blogCategory = await _db.BlogCategories
                .Include(a => a.Blogs)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (blogCategory == null)
            {
                return StatusCode(404);
            }

            if (blogCategory.Blogs.Count != 0)
            {
                return StatusCode(403);
            }

            _db.Remove(blogCategory);
            await _db.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpPost]
        [Route("[controller]/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string categoryName, int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(categoryName))
            {
                TempData["Error"] = "لطفا نام دسته را وارد نمایید";
                return RedirectToAction("Index");
            }

            var category = await _db.BlogCategories.FindAsync(id);

            if (category == null)
            {
                TempData["Error"] = "دسته یافت نشد";
                return RedirectToAction("Index");
            }

            category.Name = categoryName;

            _db.BlogCategories.Update(category);
            await _db.SaveChangesAsync();

            TempData["Success"] = "دسته " + category.Name + " با موفقیت ویرایش شد";
            return RedirectToAction("Index");
        }
    }
}
