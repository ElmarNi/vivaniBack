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
    public class FetchController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private VivaniDbContext _context;
        public FetchController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpPost]
        public async Task<bool> updateContactMessageStatus(int? id)
        {
            if (id != null && await _context.contactForms.AnyAsync(c => c.Id == (int)id))
            {
                ContactForm message = await _context.contactForms.FindAsync((int)id);
                message.IsResponsed = !message.IsResponsed;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> updateContactMessageShowInHomeStatus(int? id)
        {
            if (id != null && await _context.contactForms.AnyAsync(c => c.Id == (int)id))
            {
                ContactForm message = await _context.contactForms.FindAsync((int)id);
                message.ShowInHome = !message.IsResponsed;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> deleteSlider(int? id)
        {
            if (id != null && await _context.homeSliders.AnyAsync(c => c.Id == (int)id))
            {
                HomeSlider slider = await _context.homeSliders.FindAsync((int)id);
                RemovePhoto(_env.WebRootPath, slider.ImageUrl);
                _context.homeSliders.Remove(slider);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> deleteCategory(int? id)
        {
            if (id != null && await _context.ProductCategories.AnyAsync(c => c.Id == (int)id))
            {
                ProductCategory productCategory = await _context.ProductCategories.FindAsync((int)id);
                _context.ProductCategories.Remove(productCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> deleteType(int? id)
        {
            if (id != null && await _context.productTypes.AnyAsync(c => c.Id == (int)id))
            {
                ProductType productType = await _context.productTypes.FindAsync((int)id);
                _context.productTypes.Remove(productType);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> deleteProduct(int? id)
        {
            if (id != null && await _context.products.AnyAsync(c => c.Id == (int)id))
            {
                Product product = await _context.products.Where(p => p.Id == id).Include(p => p.ProductImages).FirstOrDefaultAsync();
                RemovePhoto(_env.WebRootPath, product.MainImageUrl);
                foreach (var item in product.ProductImages)
                {
                    RemovePhoto(_env.WebRootPath, item.ImageUrl);
                }
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> deleteProductImage(int? id)
        {
            if (id != null && await _context.productImages.AnyAsync(c => c.Id == (int)id))
            {
                ProductImage productImage = await _context.productImages.FindAsync((int)id);
                RemovePhoto(_env.WebRootPath, productImage.ImageUrl);
                _context.productImages.Remove(productImage);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

