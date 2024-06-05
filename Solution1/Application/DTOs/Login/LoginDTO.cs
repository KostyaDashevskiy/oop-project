using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Login
{
    //класс определяет какие поля мы получаем в запросе на ЛОГИН
    public class LoginDTO
    {
        [Required]
        public string? UserName  { get; set; } = string.Empty;

        [Required]
        public string? Password { get; set; } = string.Empty;
    }
}
