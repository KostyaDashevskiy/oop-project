using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Twitch
{
    //класс определяет какие поля мы получаем в запросе на ТВИТЧ
    public class TwitchDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string TwitchLink { get; set; } = default!;
    }
}
