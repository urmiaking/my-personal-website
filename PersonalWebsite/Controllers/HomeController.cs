﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersonalWebsite.Data;
using PersonalWebsite.DTOs;
using PersonalWebsite.Models;

namespace PersonalWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var indexViewModel = new IndexViewModel()
            {
                AboutMe = await _db.AboutMe
                    .Include(a => a.Technologies)
                    .FirstOrDefaultAsync(a => a.Id.Equals(1)),
                ContactForm = new ContactForm(),
                ContactMe = await _db.ContactMe.FindAsync(1),
                Educations = await _db.Educations.ToListAsync(),
                Experiences = await _db.Experiences
                    .Include(a => a.ExperienceTools)
                    .ThenInclude(a => a.Tool)
                    .ToListAsync(),
                PersonalSkills = await _db.PersonalSkills.ToListAsync(),
                TechnicalSkills = await _db.TechnicalSkills.ToListAsync(),
                WorkSamples = await _db.WorkSamples
                    .Include(a => a.WorkSampleCategories)
                    .ThenInclude(a => a.Category)
                    .Include(a => a.Detail)
                    .ToListAsync(),
                Blogs = await _db.Blogs.Include(a => a.Category).Take(3).OrderByDescending(a => a.DateTime)
                    .ToListAsync()
            };
            return View(indexViewModel);
        }
    }
}
