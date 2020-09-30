using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Data;
using PersonalWebsite.Models.Weblog;
using PersonalWebsite.Services;
using PersonalWebsite.Utilities;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IPictureService _pictureService;

        public BlogController(AppDbContext db, IPictureService pictureService)
        {
            _db = db;
            _pictureService = pictureService;
        }


        #region Blog Archive

        public async Task<IActionResult> Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var blogs = _db.Blogs.OrderByDescending(b => b.DateTime);

            var pageSize = 6;
            var pageNumber = (page ?? 1);

            if (string.IsNullOrEmpty(searchString))
            {
                return View(await PaginatedList<Blog>.CreateAsync(blogs.AsNoTracking(), pageNumber, pageSize));
            }

            var searchBlogResults = _db.Blogs
                .OrderByDescending(a => a.DateTime)
                .Where(a =>
                    a.Title.Contains(searchString) ||
                    a.Description.Contains(searchString) ||
                    a.ShortDescription.Contains(searchString) ||
                    a.Tags.Contains(searchString));

            return View(await PaginatedList<Blog>.CreateAsync(searchBlogResults.AsNoTracking(), pageNumber, pageSize));
        }

        #endregion

        #region Add Blog

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
            return RedirectToAction("Index", "Blog", new {area = "Admin"});

        }

        #endregion

        #region Get Blog

        [Route("[controller]/Details/{id}")]
        public async Task<IActionResult> GetBlog(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var blog = await _db.Blogs.Include(a => a.Category).FirstOrDefaultAsync(b => b.Id.Equals(id));

            if (blog is null)
            {
                return NotFound();
            }

            return View(blog);
        }

        #endregion

        #region Edit Blog

        [HttpGet]
        [Route("[controller]/Edit/{id}")]
        public async Task<IActionResult> EditBlog(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var blog = await _db.Blogs
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (blog is null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpPost]
        [Route("[controller]/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(Blog blog, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            if (imageFile != null)
            {
                var newImageName = await _pictureService.EditBlogImageAsync(blog.ImageUrl, blog.Id, imageFile);

                if (string.IsNullOrEmpty(newImageName))
                {
                    ModelState.AddModelError("Tags", "حجم عکس آپلود شده بیش از 500 کیلوبایت می باشد");
                    return View(blog);
                }

                blog.ImageUrl = newImageName;
            }

            _db.Blogs.Update(blog);
            await _db.SaveChangesAsync();

            TempData["Success"] = "بلاگ مورد نظر با موفقیت ویرایش شد";
            return RedirectToAction("GetBlog", "Blog", new {area="Admin", id=blog.Id});
        }

        #endregion

        #region Delete Blog

        public async Task<IActionResult> DeleteBlog(int id = 0)
        {
            if (id == 0)
            {
                return StatusCode(404);
            }

            var blog = await _db.Blogs.FindAsync(id);

            if (blog is null)
            {
                return StatusCode(404);
            }

            var blogImageRemoved = _pictureService.RemoveBlogImage(blog.ImageUrl, blog.Id);

            if (!blogImageRemoved)
            {
                //TODO: Log this
                Console.WriteLine("Image Cannot be deleted");
            }

            _db.Blogs.Remove(blog);
            await _db.SaveChangesAsync();

            return StatusCode(200);
        }

        #endregion
    }
}
