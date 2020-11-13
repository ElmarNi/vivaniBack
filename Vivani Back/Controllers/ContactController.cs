using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Controllers
{
    public class ContactController : Controller
    {
        public VivaniDbContext _context { get; set; }
        public ContactController (VivaniDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ContactVM VM = new ContactVM
            {
                contact = _context.contact
            };
            return View(VM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactForm form)
        {
            ContactVM VM = new ContactVM
            {
                contact = _context.contact
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
                Date = DateTime.Now
            };
            await _context.contactForms.AddAsync(newForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
