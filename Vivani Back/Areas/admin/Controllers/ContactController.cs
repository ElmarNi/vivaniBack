using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VivaniBack.DAL;
using VivaniBack.Models;
using static VivaniBack.Extensions.IFormFileEx;

namespace VivaniBack.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ContactController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                return View(_context.contact.FirstOrDefault());
            }
            return Redirect("/admin/account");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                Contact contactFromDb = _context.contact.FirstOrDefault();
                if (contactFromDb == null) return NotFound();

                if (!ModelState.IsValid || contact == null)
                {
                    return NotFound();
                }
                if (string.IsNullOrEmpty(contact.MainHeader))
                {
                    ModelState.AddModelError("MainHeader", "Əsas Başlıq boş olmamalıdır");
                    return View(contactFromDb);
                }
                if (string.IsNullOrEmpty(contact.SmallHeader))
                {
                    ModelState.AddModelError("SmallHeader", "Kiçik Başlıq boş olmamalıdır");
                    return View(contactFromDb);
                }
                if (string.IsNullOrEmpty(contact.Adress))
                {
                    ModelState.AddModelError("Adress", "Ünvan boş olmamalıdır");
                    return View(contactFromDb);
                }
                if (string.IsNullOrEmpty(contact.PhoneNumber))
                {
                    ModelState.AddModelError("PhoneNumber", "Əlaqə nömrəsi boş olmamalıdır");
                    return View(contactFromDb);
                }
                if (!int.TryParse(contact.PhoneNumber, out _))
                {
                    ModelState.AddModelError("PhoneNumber", "Nömrəniz yalnız rəqəmlərdən ibarət olmalıdır");
                    return View(contactFromDb);
                }
                if (string.IsNullOrEmpty(contact.Email))
                {
                    ModelState.AddModelError("Email", "Email boş olmamalıdır");
                    return View(contactFromDb);
                }
                if (string.IsNullOrEmpty(contact.Hours))
                {
                    ModelState.AddModelError("Hours", "İş saatları boş olmamalıdır");
                    return View(contactFromDb);
                }
                if (contact.Image != null)
                {
                    if (!contact.Image.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("Image", "Şəkilin formatı düzgün deyil");
                        return View(contactFromDb);
                    }
                    RemovePhoto(_env.WebRootPath, contactFromDb.ImageUrl);
                    contactFromDb.ImageUrl = await contact.Image.SavePhotoAsync(_env.WebRootPath, "contact");
                }
                contactFromDb.MainHeader = contact.MainHeader;
                contactFromDb.SmallHeader = contact.SmallHeader;
                contactFromDb.Adress = contact.Adress;
                contactFromDb.PhoneNumber = contact.PhoneNumber;
                contactFromDb.Email = contact.Email;
                contactFromDb.Hours = contact.Hours;
                await _context.SaveChangesAsync();
                ViewBag.Success = "Məlumat uğurla yeniləndi";
                return View(contactFromDb);
            }
            return Redirect("/admin/account");
        }
    }
}
