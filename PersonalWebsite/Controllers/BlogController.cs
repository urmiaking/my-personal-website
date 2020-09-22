using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite.Data;

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
        public IActionResult Index()
        {
            return View();
        }

        [Route("[controller]")]
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
