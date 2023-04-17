using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductTypeController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductTypeController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View(_context.productTypes);

            return Redirect("/admin/account");
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View();

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductType productType)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid) return View(productType);

                _context.productTypes.Add(productType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return Redirect("/admin/account");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (id == null || !await _context.productTypes.AnyAsync(c => c.Id == id)) return NotFound();
                return View(await _context.productTypes.FindAsync(id));
            }

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductType productType)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid) return View(productType);
                ProductType productTypeFromDb = await _context.productTypes.FindAsync(productType.Id);
                productTypeFromDb.Name = productType.Name;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return Redirect("/admin/account");
        }
    }
}

