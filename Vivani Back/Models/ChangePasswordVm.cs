using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VivaniBack.Models
{
    public class ChangePasswordVm
    {
        [Required(ErrorMessage = "Şifrə boş olmamalıdır"), DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage ="Şifrə boş olmamalıdır"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrə boş olmamalıdır"), Compare(nameof(Password), ErrorMessage = "Şifrə eyni deyil"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
