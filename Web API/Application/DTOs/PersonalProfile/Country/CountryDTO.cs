using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.PersonalProfile.Country
{
    //класс определяет какие поля мы получаем в запросе на "СТРАНУ"
    public class CountryDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Country { get; set; } = default!;
    }
}
