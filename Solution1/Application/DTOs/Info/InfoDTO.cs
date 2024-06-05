using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Info
{
    //класс определяет какие поля мы получаем в запросе на ИНФОРМАЦИЮ О ПОЛЬЗОВАТЕЛЕ
    public class InfoDTO
    {
        [Required]
        public string UserName { get; set; } = default!;
    }
}
