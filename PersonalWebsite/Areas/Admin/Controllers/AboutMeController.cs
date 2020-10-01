using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Data;
using PersonalWebsite.Models;
using PersonalWebsite.Services;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AboutMeController : Controller
    {
        private readonly AppDbContext _db;

        private readonly IPictureService _pictureService;

        public AboutMeController(AppDbContext db, IPictureService pictureService)
        {
            _db = db;
            _pictureService = pictureService;
        }

        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            var aboutMe = await _db.AboutMe
                .Include(a => a.Technologies)
                .FirstOrDefaultAsync(a => a.Id.Equals(1));
            return View(aboutMe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Edit(AboutMe aboutMe, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", aboutMe);
            }

            if (imageFile != null)
            {
                var newImageName = await _pictureService.EditAboutMeImageAsync(imageFile, aboutMe.Image);

                if (string.IsNullOrEmpty(newImageName))
                {
                    TempData["Error"] = "حجم عکس بیش از 500 کیلوبایت می باشد";
                    return RedirectToAction("Index");
                }

                aboutMe.Image = newImageName;
            }

            _db.AboutMe.Update(aboutMe);
            await _db.SaveChangesAsync();

            TempData["Success"] = "اطلاعات با موفقیت ذخیره شد";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> AddSkill(string skillName)
        {
            if (string.IsNullOrEmpty(skillName))
            {
                TempData["Error"] = "عنوان مهارت نامعتبر است";
                return RedirectToAction("Index");
            }

            if (await _db.Technologies.CountAsync() > 30)
            {
                TempData["Error"] = "تعداد مهارت ها به حداکثر حد مجاز رسیده است";
                return RedirectToAction("Index");
            }

            var technology = new Technology()
            {
                AboutMeId = 1,
                Title = skillName
            };

            await _db.Technologies.AddAsync(technology);
            await _db.SaveChangesAsync();

            TempData["Success"] = "مهارت با موفقیت افزوده شد";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> EditSkill(string skillName, int id = 0)
        {
            if (id == 0 || string.IsNullOrEmpty(skillName))
            {
                TempData["Error"] = "عنوان مهارت نامعتبر است";
                return RedirectToAction("Index");
            }

            var technology = await _db.Technologies.FindAsync(id);

            if (technology is null)
            {
                TempData["Error"] = "لطفا از دستکاری داده ها اجتناب کنید";
                return RedirectToAction("Index");
            }

            technology.Title = skillName;

            _db.Technologies.Update(technology);
            await _db.SaveChangesAsync();

            TempData["Success"] = "مهارت با موفقیت ویرایش شد";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> DeleteSkill(int id = 0)
        {
            if (id is 0)
            {
                return StatusCode(404);
            }

            var skill = await _db.Technologies.FindAsync(id);

            if (skill is null)
            {
                return StatusCode(404);
            }

            _db.Technologies.Remove(skill);
            await _db.SaveChangesAsync();

            return StatusCode(200);
        }
    }
}
