using Application.Contract.GameProfile;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.GameProfile.Rating
{
    //класс определяет какие поля мы получаем в запросе на "РЕЙТИНГ"
    public class RatingDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public RatigStatus status { get; set; } = default!;
    }
}
