using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivaniBack.DAL;
using VivaniBack.ViewModels;

namespace VivaniBack.Controllers
{
    public class ProductsController : Controller
    {
        private readonly VivaniDbContext _context;
        public ProductsController(VivaniDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ProductsVm model = new ProductsVm
            {
                productCategories = _context.ProductCategories,
                productTypes = _context.productTypes,
                products = _context.products.OrderByDescending(p => p.IsNew).ThenByDescending(p => p.Date).Take(18)
            };

            ViewBag.Max = model.products.OrderByDescending(p => p.Price).FirstOrDefault().Price;
            ViewBag.NumberOfPages = Math.Ceiling(_context.products.Count() / 18.0);

            return View(model);
        }
    }
}

