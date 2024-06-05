using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.RegisterUser
{
    //класс определяет какие поля мы получаем в запросе на РЕГИСТРАЦИЮ
    public record RegisterUserDTO()
    {
        [Required]
        public string? UserName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string? Email { get; set; } = string.Empty;

        [Required]
        public string? Password { get; set; } = string.Empty;

        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; } = string.Empty;
    }
}
