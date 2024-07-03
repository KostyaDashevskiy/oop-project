using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Guild.EditDescription
{
    //класс определяет какие поля мы получаем в запросе на "ИЗМЕНЕНИЕ ОПИСАНИЯ ГИЛЬДИИ"
    public class EditGuildDescriptionDTO
    {
        [Required]
        public string GuildName { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public string UserName { get; set;} = default!;
    }
}
