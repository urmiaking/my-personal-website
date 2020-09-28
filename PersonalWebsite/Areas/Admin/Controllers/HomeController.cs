using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Data;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.lastMonthVisitCount = await _db.ClientVisits.CountAsync(x =>
                DateTime.Compare(x.DateTime, DateTime.Today.AddMonths(-1)) >= 0);

            ViewBag.TotalVisits = await _db.ClientVisits.CountAsync();

            ViewBag.TodayVisits = await _db.ClientVisits.CountAsync(a => a.DateTime > DateTime.Today);

            var dashboardViewModel = new DashboardViewModel()
            {
                Blogs = await _db.Blogs.Include(a => a.Category).OrderByDescending(a => a.DateTime).Take(6).ToListAsync()
            };

            return View(dashboardViewModel);
        }
    }
}
