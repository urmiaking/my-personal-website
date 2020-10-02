using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Data;
using PersonalWebsite.Models;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _db;

        public PortfolioController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var portfolioViewModel = new PortfolioViewModel()
            {
                WorkSample = new WorkSample(),
                WorkSamples = await _db.WorkSamples
                    .Include(a => a.Detail)
                    .Include(a => a.WorkSampleCategories)
                    .OrderByDescending(a => a.CreateDateTime)
                    .ToListAsync()
            };
            return View(portfolioViewModel);
        }
    }
}
