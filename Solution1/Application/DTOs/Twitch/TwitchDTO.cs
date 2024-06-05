using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
