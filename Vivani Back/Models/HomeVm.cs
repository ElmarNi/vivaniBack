using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VivaniBack.Models
{
    public class HomeVm
    {
        public IEnumerable<HomeSlider> homeSliders { get; set; }
        public IEnumerable<WhyChooseUs> whyChooseUs { get; set; }
        public IEnumerable<TrendingProductsImage> trendingProductsImage { get; set; }
    }
}
