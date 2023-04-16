using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivaniBack.DAL;
using VivaniBack.Models;
using static VivaniBack.Extensions.IFormFileEx;

namespace VivaniBack.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View(await _context.about.FirstOrDefaultAsync());

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(About about)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid) return View(about);

                About aboutDb = _context.about.FirstOrDefault();
                if (aboutDb == null) return NotFound();

                if (about.Image != null)
                {
                    if (!about.Image.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("Image", "Şəklin formatı düzgün deyil");
                        return View(aboutDb);
                    }
                    RemovePhoto(_env.WebRootPath, aboutDb.ImageUrl);
                    aboutDb.ImageUrl = await about.Image.SavePhotoAsync(_env.WebRootPath, "about");
                }
                aboutDb.Content = about.Content;
                await _context.SaveChangesAsync();
                ViewBag.Success = "Məlumat uğurla yeniləndi";
                return View(aboutDb);
            }
            return Redirect("/admin/account");
        }
    }
}

