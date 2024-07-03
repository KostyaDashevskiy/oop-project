using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ApplicationUser.Login
{
    //класс определяет какие поля мы получаем в запросе на "ЛОГИН"
    public class LoginDTO
    {
        [Required]
        public string? UserName { get; set; } = string.Empty;

        [Required]
        public string? Password { get; set; } = string.Empty;
    }
}
