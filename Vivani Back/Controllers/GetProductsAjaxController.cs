
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Controllers
{
    public class GetProductsAjaxController : Controller
    {
        private readonly VivaniDbContext _context;
        public GetProductsAjaxController(VivaniDbContext context)
        {
            _context = context;
        }
        public IActionResult getProducts(int?[] categoryIds, int?[] typeIds, int? min, int? max, int? page)
        {
            if (categoryIds != null && typeIds != null && min != null && max != null && page != null)
            {
                List<Product> products = _context.products
                                                    .Where(p => categoryIds.Contains(p.ProductCategoryId) && typeIds.Contains(p.ProductTypeId) &&
                                                                p.Price >= min && p.Price <= max)
                                                    .OrderByDescending(p => p.IsNew).ThenByDescending(p => p.Date).ToList();
                
                ViewBag.NumberOfPages = Math.Ceiling(products.Count() / 18.0);
                ViewBag.Page = page;
                return products.Any() ? PartialView("ProductsPartialView", products.Skip(18 * ((int)page - 1)).Take(18)) : PartialView("ProductsNotFoundPartialView");
            }

            return PartialView("ProductsNotFoundPartialView");
        }
    }
}

