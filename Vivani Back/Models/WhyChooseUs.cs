using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VivaniBack.Models
{
    public class WhyChooseUs
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Başlıq boş olmamalıdır")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Məzmun boş olmamalıdır")]
        public string Content { get; set; }

        [Required(ErrorMessage = "İkon boş olmamalıdır")]
        public string Icon { get; set; }
    }
}
