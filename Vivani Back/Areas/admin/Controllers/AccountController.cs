using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Areas.admin.Controllers
{

    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, VivaniDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(LoginVm login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            AppUser logedUser = await _userManager.FindByNameAsync(login.Username);
            if (logedUser == null)
            {
                ModelState.AddModelError("", "Username və ya şifrə yanlışdır");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(logedUser, login.Password, false, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username və ya şifrə yanlışdır");
                return View();
            }
            if (await _userManager.IsInRoleAsync(logedUser, "admin"))
            {
                return Redirect("/admin/dashboard/index");
            }
            
            return View(login);
        }
    }
}
