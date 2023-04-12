using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Areas.admin.Controllers
{
    public class FetchController : Controller
    {
        private VivaniDbContext _context;
        public FetchController(VivaniDbContext context)
        {
            _context = context;
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
    }
}

