using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VivaniBack.Models;

namespace VivaniBack.ViewModels
{
    public class HomeVm
    {
        public IEnumerable<HomeSlider> homeSliders { get; set; }
        public IEnumerable<WhyChooseUs> whyChooseUs { get; set; }
        public TrendingProductsImage trendingProductsImage { get; set; }
        public IEnumerable<Product> bestSellerProducts { get; set; }
        public IEnumerable<Product> trendingProducts { get; set; }
    }
}
