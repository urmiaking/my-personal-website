using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalWebsite.Data;

namespace PersonalWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly AppDbContext _db;

        public MessageController(AppDbContext db)
        {
            _db = db;
        }

        [Route("Messages")]
        public async Task<IActionResult> Index()
        {
            var messages = await _db.ContactForms.ToListAsync();
            return View(messages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id = 0)
        {
            if (id is 0)
            {
                return NotFound();
            }

            var message = await _db.ContactForms.FindAsync(id);

            if (message is null)
            {
                return NotFound();
            }

            _db.ContactForms.Remove(message);
            await _db.SaveChangesAsync();

            TempData["Success"] = "بازخورد با موفقیت حذف شد";
            return RedirectToAction("Index");
        }

    }
}
