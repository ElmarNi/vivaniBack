using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VivaniBack.Models;

namespace VivaniBack.DAL
{
    public class VivaniDbContext : DbContext
    {
        public VivaniDbContext(DbContextOptions<VivaniDbContext> options) : base(options) { }
        public DbSet<HomeSlider> homeSliders { get; set; }
        public DbSet<WhyChooseUs> whyChooseUs { get; set; }
        public DbSet<TrendingProductsImage> trendingProductsImage { get; set; }
        public DbSet<Contact> contact { get; set; }
        public DbSet<ContactForm> contactForms { get; set; }
    }
}
