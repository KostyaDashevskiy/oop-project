using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Info
{
    //класс определяет какие поля мы получаем в запросе на ИНФОРМАЦИЮ О ПОЛЬЗОВАТЕЛЕ
    public class InfoDTO
    {
        [Required]
        public string UserName { get; set; } = default!;
    }
}
