using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Guild.RegisterGuild
{
    //класс определяет какие поля мы получаем в запросе на "СОЗДАНИЕ ГИЛЬДИИ"
    public class RegistrationGuildDTO
    {
        [Required]
        public string GuildName { get; set; } = default!;

        [Required]
        public string UserName { get; set; } = default!;
    }
}
