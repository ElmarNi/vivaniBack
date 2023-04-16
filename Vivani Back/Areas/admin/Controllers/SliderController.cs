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
    public class SliderController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View(_context.homeSliders);

            return Redirect("/admin/account");
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View();

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeSlider slider)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid) return View(slider);
                if (slider.Image == null)
                {
                    ModelState.AddModelError("Image", "Şəkil boş ola bilməz");
                    return View(slider);
                }
                if (!slider.Image.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Image", "Şəklin formatı düzgün deyil");
                    return View(slider);
                }
                HomeSlider newSlider = new HomeSlider
                {
                    LittleHeader = slider.LittleHeader,
                    LargeHeader = slider.LargeHeader,
                    ImageUrl = await slider.Image.SavePhotoAsync(_env.WebRootPath, "slider")
                };
                await _context.homeSliders.AddAsync(newSlider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/admin/account");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (id == null || await _context.homeSliders.FindAsync(id) == null) return NotFound();

                return View(await _context.homeSliders.FindAsync(id));
            }
            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(HomeSlider slider)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid) return View(slider);

                HomeSlider sliderFromDb = await _context.homeSliders.FindAsync(slider.Id);
                if (sliderFromDb == null) return NotFound();

                if (slider.Image != null)
                {
                    if (!slider.Image.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("Image", "Şəklin formatı düzgün deyil");
                        return View(sliderFromDb);
                    }
                    RemovePhoto(_env.WebRootPath, sliderFromDb.ImageUrl);
                    sliderFromDb.ImageUrl = await slider.Image.SavePhotoAsync(_env.WebRootPath, "slider");
                }
                sliderFromDb.LittleHeader = slider.LittleHeader;
                sliderFromDb.LargeHeader = slider.LargeHeader;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/admin/account");
        }
    }
}

