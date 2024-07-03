using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.PersonalProfile.Age
{
    //класс определяет какие поля мы получаем в запросе на "ВОЗРАСТ"
    public class AgeDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public int Age { get; set; } = default!;
    }
}
