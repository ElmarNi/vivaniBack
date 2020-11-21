using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VivaniBack.DAL;

namespace VivaniBack.Controllers
{
    public class AboutController : Controller
    {
        public VivaniDbContext _context { get; set; }
        public AboutController(VivaniDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.about.FirstOrDefault());
        }
    }
}
