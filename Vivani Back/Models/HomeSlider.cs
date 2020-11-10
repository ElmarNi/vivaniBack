using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VivaniBack.Models
{
    public class HomeSlider
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public string LittleHeader { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
