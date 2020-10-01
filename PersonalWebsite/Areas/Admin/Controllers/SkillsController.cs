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
using PersonalWebsite.Utilities;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SkillsController : Controller
    {
        private readonly AppDbContext _db;

        public SkillsController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var skillViewModel = new SkillViewModel
            {
                TechnicalSkills = await _db.TechnicalSkills.ToListAsync(),
                PersonalSkills = await _db.PersonalSkills.ToListAsync()
            };
            return View(skillViewModel);
        }

        #region Personal Skill

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> EditPersonalSkills(List<PersonalSkill> personalSkills)
        {
            _db.PersonalSkills.UpdateRange(personalSkills);
            await _db.SaveChangesAsync();

            TempData["Success"] = "اطلاعات با موفقیت بروزرسانی شد";
            return RedirectToAction("Index");
        }

        #endregion

        #region Technical Skill

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> AddTechnicalSkill(string technicalSkillName, int technicalSkillProgress = 0)
        {
            if (string.IsNullOrEmpty(technicalSkillName))
            {
                TempData["Error"] = "لطفا داده های مورد نیاز را وارد کنید";
                return RedirectToAction("Index");
            }

            var technicalSkill = new TechnicalSkill
            {
                Progress = technicalSkillProgress,
                Title = technicalSkillName
            };

            await _db.TechnicalSkills.AddAsync(technicalSkill);
            await _db.SaveChangesAsync();

            TempData["Success"] = "مهارت با موفقیت اضافه شد";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> EditTechnicalSkills(List<TechnicalSkill> technicalSkills)
        {
            _db.TechnicalSkills.UpdateRange(technicalSkills);
            await _db.SaveChangesAsync();

            TempData["Success"] = "اطلاعات با موفقیت بروزرسانی شد";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> DeleteTechnicalSkills([ModelBinder(typeof(SkillRemoveModelBinder))] List<int> ids)
        {
            var skills = new List<TechnicalSkill>();
            foreach (var id in ids)
            {
                skills.Add(await _db.TechnicalSkills.FindAsync(id));
            }
            _db.TechnicalSkills.RemoveRange(skills);
            await _db.SaveChangesAsync();

            TempData["Success"] = "اطلاعات با موفقیت بروزرسانی شد";
            return RedirectToAction("Index");
        }

        #endregion
    }
}
