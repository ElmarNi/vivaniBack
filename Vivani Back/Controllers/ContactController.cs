using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivaniBack.DAL;
using VivaniBack.Models;
using VivaniBack.ViewModels;

namespace VivaniBack.Controllers
{
    public class ContactController : Controller
    {
        public VivaniDbContext _context { get; set; }
        public ContactController (VivaniDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ContactVM VM = new ContactVM
            {
                contact = await _context.contact.FirstOrDefaultAsync()
            };
            return View(VM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactForm form)
        {
            ContactVM VM = new ContactVM
            {
                contact = await _context.contact.FirstOrDefaultAsync()
            };
            if (form == null)
            {
                return PartialView("ErrorPage");
            }
            if (!ModelState.IsValid)
            {
                return PartialView("ErrorPage");
            }

            ContactForm newForm = new ContactForm
            {
                Fullname = form.Fullname,
                PhoneNumber = form.PhoneNumber,
                Email = form.Email,
                Message = form.Message,
                Date = DateTime.Now,
                IsResponsed = false
            };
            await _context.contactForms.AddAsync(newForm);
            await _context.SaveChangesAsync();
            ViewBag.Success = "Mesajınız uğurla göndərilmişdir";
            return View(new ContactVM { contact = _context.contact.FirstOrDefault()});
        }
    }
}
