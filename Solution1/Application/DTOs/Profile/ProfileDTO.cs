using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Profile
{
    //класс определяет какие поля мы получаем в запросе на ПРОФИЛЬ
    public class ProfileDTO
    {
        [Required]
        public string UserName { get; set; } = default!;
    }
}
