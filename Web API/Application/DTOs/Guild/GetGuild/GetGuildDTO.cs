using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Guild.GetGuild
{
    //класс определяет какие поля мы получаем в запросе на "ПОЛУЧЕНИЕ ГИЛЬДИИ"
    public class GetGuildDTO
    {
        [Required]
        public string GuildName { get; set; } = default!;
    }
}
