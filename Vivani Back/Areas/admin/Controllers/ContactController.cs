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
        private readonly IHostingEnvironment _env;
        public ContactController(VivaniDbContext context, IHostingEnvironment env)
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
        public async Task<IActionResult> Update(int? id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (id == null || await _context.contact.FindAsync(id) == null)
                {
                    return NotFound();
                }
                return View(await _context.contact.FindAsync(id));
            }
            return Redirect("/admin/account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Contact contact)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                if (!ModelState.IsValid || contact == null)
                {
                    return NotFound();
                }
                if (contact.MainHeader == string.Empty)
                {
                    ModelState.AddModelError("", "Əsas Başlıq boş olmamalıdır");
                    return View(contact);
                }
                if (contact.SmallHeader == string.Empty)
                {
                    ModelState.AddModelError("", "Kiçik Başlıq boş olmamalıdır");
                    return View(contact);
                }
                if (contact.Adress == string.Empty)
                {
                    ModelState.AddModelError("", "Ünvan boş olmamalıdır");
                    return View(contact);
                }
                if (contact.PhoneNumber == string.Empty)
                {
                    ModelState.AddModelError("", "Əlaqə nömrəsi boş olmamalıdır");
                    return View(contact);
                }
                if (contact.Email == string.Empty)
                {
                    ModelState.AddModelError("", "Email boş olmamalıdır");
                    return View(contact);
                }
                if (contact.Hours == string.Empty)
                {
                    ModelState.AddModelError("", "İş saatları boş olmamalıdır");
                    return View(contact);
                }
                Contact contactFromDb = await _context.contact.FindAsync(contact.Id);
                if (contact.Image != null)
                {
                    if (!contact.Image.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("", "Şəkilin formatı düzgün deyil");
                        return View(contactFromDb);
                    }
                    RemovePhoto(_env.WebRootPath, contactFromDb.ImageUrl);
                    contactFromDb.ImageUrl = await contact.Image.SavePhotoAsync(_env.WebRootPath, "contactPhoto");
                }
                contactFromDb.MainHeader = contact.MainHeader;
                contactFromDb.SmallHeader = contact.SmallHeader;
                contactFromDb.Adress = contact.Adress;
                contactFromDb.PhoneNumber = contact.PhoneNumber;
                contactFromDb.Email = contact.Email;
                contactFromDb.Hours = contact.Hours;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/admin/account");
        }
    }
}
