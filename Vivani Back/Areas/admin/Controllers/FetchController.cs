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
                ContactForm message = await _context.contactForms.FirstOrDefaultAsync(c => c.Id == (int)id);
                message.IsResponsed = !message.IsResponsed;
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
                HomeSlider slider = await _context.homeSliders.FirstOrDefaultAsync(c => c.Id == (int)id);
                RemovePhoto(_env.WebRootPath, slider.ImageUrl);
                _context.homeSliders.Remove(slider);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

