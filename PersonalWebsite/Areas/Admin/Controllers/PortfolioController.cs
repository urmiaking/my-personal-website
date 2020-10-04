using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Areas.Admin.DTOs;
using PersonalWebsite.Data;
using PersonalWebsite.Models;
using PersonalWebsite.Services;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IPictureService _pictureService;

        public PortfolioController(AppDbContext db, IPictureService pictureService)
        {
            _db = db;
            _pictureService = pictureService;
        }

        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            var portfolioViewModel = new PortfolioViewModel()
            {
                WorkSamples = await _db.WorkSamples
                    .Include(a => a.Detail)
                    .Include(a => a.WorkSampleCategories)
                    .ThenInclude(a => a.Category)
                    .OrderByDescending(a => a.CreateDateTime)
                    .ToListAsync()
            };
            return View(portfolioViewModel);
        }

        [Route("[controller]/[action]/{id}")]
        public async Task<IActionResult> Details(int id = 0)
        {
            if (id is 0)
            {
                return NotFound();
            }

            var workSample = await _db.WorkSamples
                .Include(a => a.Detail)
                .Include(a => a.WorkSampleCategories)
                .ThenInclude(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (workSample is null)
            {
                return NotFound();
            }

            return View(workSample);
        }

        [Route("[controller]/[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Add(WorkSample workSample, IFormFile imageFile, IFormFile innerImageFile, List<Group> groups)
        {
            if (!ModelState.IsValid || imageFile is null || groups.Count is 0)
            {
                return View(workSample);
            }

            workSample.CreateDateTime = DateTime.Now;
            var result = await _pictureService.SaveWorkSampleImageAsync(imageFile);

            if (result.ImageName == null)
            {
                TempData["Error"] = "لطفا برای نمونه کار خود عکسی انتخاب کنید";
                return View(workSample);
            }

            if (result.SizeLimitReached)
            {
                TempData["Error"] = "حجم عکس نمونه کار نباید بیشتر از 500 کیلوبایت باشد";
                return View(workSample);
            }

            if (result.SavedSuccessfully)
            {
                workSample.Image = result.ImageName;

                if (innerImageFile != null)
                {
                    var innerResult = await _pictureService.SaveWorkSampleImageAsync(innerImageFile);

                    if (innerResult.SizeLimitReached)
                    {
                        TempData["Error"] = "حجم عکس نمونه کار نباید بیشتر از 500 کیلوبایت باشد";
                        return View(workSample);
                    }

                    if (innerResult.SavedSuccessfully)
                    {
                        workSample.Detail.Image = innerResult.ImageName;
                    }
                }

                await _db.WorkSamples.AddAsync(workSample);
                await _db.SaveChangesAsync();

                foreach (var group in groups)
                {
                    var category = await _db.Categories.FirstOrDefaultAsync(a => a.Group.Equals(group));
                    var workSampleDb = await _db.WorkSamples.FirstOrDefaultAsync(a => a.Image.Equals(result.ImageName));
                    var workSampleCategory = new WorkSampleCategory
                    {
                        CategoryId = category.Id,
                        WorkSampleId = workSampleDb.Id
                    };

                    await _db.WorkSampleCategories.AddAsync(workSampleCategory);
                    await _db.SaveChangesAsync();
                }
            }

            TempData["Success"] = "نمونه کار با موفقیت اضافه شد";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Delete(int id = 0)
        {
            if (id is 0)
            {
                return StatusCode(404);
            }

            var workSample = await _db.WorkSamples
                .Include(a => a.Detail)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (workSample is null)
            {
                return StatusCode(404);
            }

            _db.Remove(workSample);
            await _db.SaveChangesAsync();

            _pictureService.RemovePortfolioImage(workSample.Image);
            _pictureService.RemovePortfolioImage(workSample.Detail.Image);

            return StatusCode(200);
        }

        [Route("[controller]/[action]/{id}")]
        public async Task<IActionResult> Edit(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var workSample = await _db.WorkSamples
                .Include(a => a.Detail)
                .Include(a => a.WorkSampleCategories)
                .ThenInclude(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (workSample is null)
            {
                return NotFound();
            }

            return View(workSample);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]/{id}")]
        public async Task<IActionResult> Edit(WorkSample workSample, IFormFile imageFile, IFormFile innerImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(workSample);
            }

            if (imageFile != null)
            {
                var isSuccessful = _pictureService.RemovePortfolioImage(workSample.Image);
                if (isSuccessful)
                {
                    var result = await _pictureService.SaveWorkSampleImageAsync(imageFile);
                    if (result.SavedSuccessfully)
                    {
                        workSample.Image = result.ImageName;
                    }
                }
            }

            if (innerImageFile != null)
            {
                var isSuccessful = _pictureService.RemovePortfolioImage(workSample.Detail.Image);
                if (isSuccessful)
                {
                    var result = await _pictureService.SaveWorkSampleImageAsync(innerImageFile);
                    if (result.SavedSuccessfully)
                    {
                        workSample.Detail.Image = result.ImageName;
                    }
                }
            }

            _db.WorkSamples.Update(workSample);
            await _db.SaveChangesAsync();

            TempData["Success"] = "نمونه کار با موفقیت ویرایش شد";
            return RedirectToAction("Index");
        }
    }
}
