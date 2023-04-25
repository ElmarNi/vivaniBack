using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VivaniBack.DAL;
using VivaniBack.Models;
using VivaniBack.ViewModels;

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
                    UserName = "admin"
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
                trendingProductsImage = await _context.trendingProductsImage.FirstOrDefaultAsync(),
                bestSellerProducts = _context.products.OrderByDescending(p => p.IsBestSeller).ThenByDescending(p => p.Date).Take(6)
            };

            if (!await _context.products.AnyAsync(p => p.IsTrendingProduct))
            {
                List<Product> products = new List<Product>();
                foreach (ProductCategory category in _context.ProductCategories.Include(c => c.Products))
                {
                    products.Add(category.Products.OrderByDescending(p => p.Date).FirstOrDefault());
                }
                vm.trendingProducts = products;
            }
            else vm.trendingProducts = _context.products.Where(p => p.IsTrendingProduct).Include(p => p.ProductCategory);

            return View(vm);
        }
    }
}
