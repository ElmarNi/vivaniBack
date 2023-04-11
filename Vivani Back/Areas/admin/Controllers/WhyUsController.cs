using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VivaniBack.DAL;
using VivaniBack.Models;
using static VivaniBack.Extensions.IFormFileEx;

namespace VivaniBack.Areas.admin.Controllers
{
    [Area("admin")]
    public class WhyUsController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;
        public WhyUsController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                IEnumerable<WhyChooseUs> model = _context.whyChooseUs;
                return View(model);
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
                WhyChooseUs fromDb = await _context.whyChooseUs.FindAsync(whyChooseUs.Id);
                if (fromDb == null) return NotFound();
                if(whyChooseUs.IconImage != null)
                {
                    if (!whyChooseUs.IconImage.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("IconImage", "Şəklin formatı düzgün deyil");
                        return View(fromDb);
                    }
                    RemovePhoto(_env.WebRootPath, fromDb.IconUrl);
                    fromDb.IconUrl = await whyChooseUs.IconImage.SavePhotoAsync(_env.WebRootPath, "whyChooseUs");
                }
                fromDb.Heading = whyChooseUs.Heading;
                fromDb.Content = whyChooseUs.Content;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/admin/account");
        }
    }
}
