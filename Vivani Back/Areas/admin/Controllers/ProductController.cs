using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View(_context.products);

            return Redirect("/admin/account");
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                List<SelectListItem> productCategories = new List<SelectListItem>();
                foreach (var item in _context.ProductCategories)
                    productCategories.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productCategories"] = productCategories;

                List<SelectListItem> productTypes = new List<SelectListItem>();
                foreach (var item in _context.productTypes)
                    productTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                ViewData["productTypes"] = productTypes;

                return View();
            }

            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
                return View();

            return Redirect("/admin/account");
        }
    }
}
