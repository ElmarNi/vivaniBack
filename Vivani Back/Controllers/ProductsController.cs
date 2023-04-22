using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int? page = 1)
        {
            ProductsVm model = new ProductsVm
            {
                productCategories = _context.ProductCategories,
                productTypes = _context.productTypes,
                products = _context.products
            };
            return View(model);
        }
    }
}

