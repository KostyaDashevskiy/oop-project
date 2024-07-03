using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.GameProfile.Profile.QuitGuild
{
    //класс определяет какие поля мы получаем в запросе на "ВЫХОД ИЗ ГИЛЬДИИ"
    public class QuitGuildDTO
    {
        [Required]
        public string GuildName { get; set; } = default!;

        [Required]
        public string UserName { get; set; } = default!;
    }
}
