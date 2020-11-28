using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Areas.admin.Controllers
{
    [Area("admin")]
    public class WhyUsController : Controller
    {
        private readonly VivaniDbContext _context;
        public WhyUsController(VivaniDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                WhyChooseUsAdminVm vm = new WhyChooseUsAdminVm
                {
                    WhyChooseUs = _context.whyChooseUs
                };
                return View(vm);
            }
            return Redirect("/admin/account");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (id == null || await _context.whyChooseUs.FindAsync(id) == null)
                {
                    return NotFound();
                }
                return View(await _context.whyChooseUs.FindAsync(id));
            }
            return Redirect("/admin/account");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(WhyChooseUs whyChooseUs)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (whyChooseUs == null || !ModelState.IsValid)
                {
                    return NotFound();
                }
                if (whyChooseUs.Heading == string.Empty)
                {
                    ModelState.AddModelError("", "Başlıq boş olmamalıdır");
                    return View(whyChooseUs);
                }
                if (whyChooseUs.Content == string.Empty)
                {
                    ModelState.AddModelError("", "Məzmun boş olmamalıdır");
                    return View(whyChooseUs);
                }
                if (whyChooseUs.Icon == string.Empty)
                {
                    ModelState.AddModelError("", "Ikon boş olmamalıdır");
                    return View(whyChooseUs);
                }
                WhyChooseUs fromDb = await _context.whyChooseUs.FindAsync(whyChooseUs.Id);
                fromDb.Heading = whyChooseUs.Heading;
                fromDb.Content = whyChooseUs.Content;
                fromDb.Icon = whyChooseUs.Icon;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/admin/account");
        }
    }
}
