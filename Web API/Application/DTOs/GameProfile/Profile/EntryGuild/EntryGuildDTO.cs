using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.GameProfile.Profile.EntryGuild
{
    //класс определяет какие поля мы получаем в запросе на "ВСТУПЛЕНИЕ В ГИЛЬДИЮ"
    public class EntryGuildDTO
    {
        [Required]
        public string GuildName { get; set; } = default!;

        [Required]
        public string UserName { get; set; } = default!;
    }
}
