using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.PersonalProfile.About
{
    //класс определяет какие поля мы получаем в запросе на "О СЕБЕ"
    public class AboutDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string About { get; set; } = default!;
    }
}
