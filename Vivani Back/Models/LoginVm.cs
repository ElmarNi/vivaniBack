using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VivaniBack.Models
{
    public class LoginVm
    {
        [Required(ErrorMessage ="Istifadəçi adı boş olmamalıdır")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Şifrə boş olmamalıdır"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
