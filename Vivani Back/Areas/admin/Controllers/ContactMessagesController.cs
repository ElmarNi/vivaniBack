using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using VivaniBack.DAL;

namespace VivaniBack.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactMessagesController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ContactMessagesController(VivaniDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                return View(_context.contactForms);
            }
            return Redirect("/admin/account");
        }
    }
}

