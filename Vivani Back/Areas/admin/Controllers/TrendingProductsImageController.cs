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
    public class TrendingProductsImageController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TrendingProductsImageController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View(await _context.trendingProductsImage.FirstOrDefaultAsync());

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TrendingProductsImage trendingProductsImage)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid) return View(trendingProductsImage);

                TrendingProductsImage imageDb = await _context.trendingProductsImage.FirstOrDefaultAsync();
                if (imageDb == null) return NotFound();

                if (trendingProductsImage.Image == null)
                {
                    ModelState.AddModelError("Image", "Şəkil boş ola bilməz");
                    return View(imageDb);
                }

                if (!trendingProductsImage.Image.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Image", "Şəklin formatı düzgün deyil");
                    return View(imageDb);
                }
                RemovePhoto(_env.WebRootPath, imageDb.ImageUrl);
                imageDb.ImageUrl = await trendingProductsImage.Image.SavePhotoAsync(_env.WebRootPath, "trendingProducts");

                await _context.SaveChangesAsync();
                ViewBag.Success = "Məlumat uğurla yeniləndi";
                return View(imageDb);
            }
            return Redirect("/admin/account");
        }
    }
}

