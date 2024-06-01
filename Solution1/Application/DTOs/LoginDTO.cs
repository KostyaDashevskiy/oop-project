using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string? Name { get; set; } = string.Empty;//поле

        [Required]
        public string? Password { get; set; } = string.Empty;//поле
    }
}
