using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Controllers
{
    public class HomeController : Controller
    {
        public VivaniDbContext _context { get; set; }
        public HomeController(VivaniDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVm vm = new HomeVm
            {
                homeSliders = _context.homeSliders
            };
            return View(vm);
        }
    }
}
