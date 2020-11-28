using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, VivaniDbContext context, IConfiguration configuration)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
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
                ModelState.AddModelError("", "İstifadəçı adı və ya şifrə yanlışdır");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(logedUser, login.Password, false, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
                return View();
            }
            if (await _userManager.IsInRoleAsync(logedUser, "admin"))
            {
                return Redirect("/admin/dashboard");
            }
            
            return View(login);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
        public IActionResult ChangePassword()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVm changePassword)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                AppUser currUser = await _userManager.GetUserAsync(User);
                if (currUser == null || !ModelState.IsValid)
                {
                    return View(changePassword);
                }
                if (!await _userManager.CheckPasswordAsync(currUser, changePassword.OldPassword))
                {
                    ModelState.AddModelError("", "Köhnə şifrə düzgün deyil");
                    return View(changePassword);
                }
                if (changePassword.Password != changePassword.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Şifrəni düzgün təsdiqləyin");
                    return View(changePassword);
                }
                var password = _configuration.GetValue<string>("Passwords:AdminPassword");
                await _userManager.ChangePasswordAsync(currUser, password, changePassword.ConfirmPassword);
                await _context.SaveChangesAsync();
                return PartialView("PasswordChanged");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
