using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ChangePassword
{
    //класс определяет какие поля мы получаем в запросе на СМЕНУ ПАРОЛЯ
    public class ChangePasswordDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string OldPassword { get; set; } = default!;

        [Required]
        public string NewPassword { get; set; } = default!;

    }
}
