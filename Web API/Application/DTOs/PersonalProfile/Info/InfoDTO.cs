using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.PersonalProfile.Info
{
    //класс определяет какие поля мы получаем в запросе на "ПЕРСОНАЛЬНУЮ ИНФОРМАЦИЮ О ПОЛЬЗОВАТЕЛЕ"
    public class InfoDTO
    {
        [Required]
        public string UserName { get; set; } = default!;
    }
}
