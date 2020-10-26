using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Data;
using PersonalWebsite.Models.Weblog;
using PersonalWebsite.Utilities;

namespace PersonalWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        //All Archives
        [Route("[controller]/Archive")]
        public async Task<IActionResult> Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
                searchString = searchString.EncodeUrl();
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            const int pageSize = 6;
            var pageNumber = (page ?? 1);

            if (string.IsNullOrEmpty(searchString))
            {
                var blogs = _db.Blogs.OrderByDescending(a => a.DateTime);
                return View(await PaginatedList<Blog>.CreateAsync(blogs.AsNoTracking(), pageNumber, pageSize));
            }

            var searchResult = _db.Blogs
                .Include(a => a.Category)
                .Where(a =>
                    a.Tags.Contains(searchString.EncodeUrl()) || a.Description.Contains(searchString.EncodeUrl()) ||
                    a.Title.Contains(searchString.EncodeUrl()) ||
                    a.ShortDescription.Contains(searchString.EncodeUrl()) ||
                    a.Category.Name.Equals(searchString.EncodeUrl()))
                .Distinct()
                .OrderByDescending(a => a.DateTime);

            return View(await PaginatedList<Blog>.CreateAsync(searchResult, pageNumber, pageSize));
        }

        [Route("[controller]/{id}/{title}")]
        public async Task<IActionResult> GetBlog(int id, string title)
        {
            var blog = await _db.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            blog.ViewCount++;
            _db.Update(blog);
            await _db.SaveChangesAsync();

            return View(blog);
        }
    }
}
