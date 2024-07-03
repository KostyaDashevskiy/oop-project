using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.GameProfile.Profile.GetProfile
{
    //класс определяет какие поля мы получаем в запросе на "ПРОФИЛЬ"
    public class ProfileDTO
    {
        [Required]
        public string UserName { get; set; } = default!;
    }
}
