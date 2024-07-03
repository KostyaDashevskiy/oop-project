using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Guild.DeleteMember
{
    //класс определяет какие поля мы получаем в запросе на "УДАЛЕНИЕ ЧЛЕНА ГИЛЬДИИ"
    public class DeleteGuildMemberDTO
    {
        [Required]
        public string GuildName { get; set; } = default!;

        [Required]
        public string UserToDelete { get; set; } = default!;

        [Required]
        public string Sender { get; set; } = default!;
    }
}
