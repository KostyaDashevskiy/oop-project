using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Guild.DeleteGuild
{
    //класс определяет какие поля мы получаем в запросе на "УДАЛЕНИЕ ГИЛЬДИИ"
    public class DeleteGuildDTO
    {
        [Required]
        public string GuildName { get; set; } = default!;

        [Required]
        public string Sender { get; set; } = default!;
    }
}
