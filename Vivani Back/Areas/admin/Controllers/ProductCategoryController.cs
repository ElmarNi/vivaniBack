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
    public class ProductCategoryController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductCategoryController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View(_context.ProductCategories);

            return Redirect("/admin/account");
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View();

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategory productCategory)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid) return View(productCategory);

                _context.ProductCategories.Add(productCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return Redirect("/admin/account");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (id == null || !await _context.ProductCategories.AnyAsync(c => c.Id == id)) return NotFound();
                return View(await _context.ProductCategories.FindAsync(id));
            }

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductCategory productCategory)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid) return View(productCategory);
                ProductCategory productCategoryFromDb = await _context.ProductCategories.FindAsync(productCategory.Id);
                productCategoryFromDb.Name = productCategory.Name;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return Redirect("/admin/account");
        }
    }
}

