using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VivaniBack.Models
{
    public class WhyChooseUs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlıq boş olmamalıdır")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Məzmun boş olmamalıdır")]
        public string Content { get; set; }

        public string IconUrl { get; set; }

        [NotMapped]
        public IFormFile IconImage { get; set; }
    }
}
