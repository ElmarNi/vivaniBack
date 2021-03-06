﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VivaniBack.DAL;
using VivaniBack.Models;

namespace VivaniBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly VivaniDbContext _context;
        private readonly UserManager<AppUser> _user;
        private readonly RoleManager<IdentityRole> _role;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<AppUser> _hash;
        public HomeController(SignInManager<AppUser> sign, IPasswordHasher<AppUser> hash,VivaniDbContext context, UserManager<AppUser> user, RoleManager<IdentityRole> role, IConfiguration configuration)
        {
            _context = context;
            _user = user;
            _role = role;
            _configuration = configuration;
            _hash = hash;
        }
        public async Task<IActionResult> Index()
        {
            var password = _configuration.GetValue<string>("Passwords:AdminPassword");
            if (!await _role.RoleExistsAsync("admin"))
            {
                await _role.CreateAsync(new IdentityRole("admin"));
            }
            var user = await _user.FindByNameAsync("admin");
            if (user == null )
            {
                
                AppUser newUser = new AppUser
                {
                    
                    UserName = "admin",
                    Firstname = "Elmar", 
                    Lastname = "Ibrahimli",
                };
                var hashed = _hash.HashPassword(newUser, password);
                newUser.PasswordHash = hashed;
                await _user.CreateAsync(newUser);
                await _user.AddToRoleAsync(newUser, "admin");
            }
            HomeVm vm = new HomeVm
            {
                homeSliders = _context.homeSliders,
                whyChooseUs = _context.whyChooseUs,
                trendingProductsImage = _context.trendingProductsImage
            };
            return View(vm);
        }
    }
}
