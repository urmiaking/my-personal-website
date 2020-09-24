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
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            if (string.IsNullOrEmpty(searchString))
            {
                var blogs = _db.Blogs.OrderByDescending(a => a.DateTime);
                return View(await PaginatedList<Blog>.CreateAsync(blogs.AsNoTracking(), pageNumber, pageSize));
            }

            var searchResult = _db.Blogs
                .Include(a => a.Category)
                .Where(a =>
                    a.Tags.Contains(searchString) || a.Description.Contains(searchString) ||
                    a.Title.Contains(searchString) ||
                    a.ShortDescription.Contains(searchString) ||
                    a.Category.Name.Equals(searchString))
                .Distinct()
                .OrderByDescending(a => a.DateTime);

            return View(await PaginatedList<Blog>.CreateAsync(searchResult, pageNumber, pageSize));
        }

        [Route("[controller]/{id}")]
        public async Task<IActionResult> GetBlog(int id = 0)
        {
            var blog = await _db.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
    }
}
