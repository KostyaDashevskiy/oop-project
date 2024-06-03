using Application.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Statistics
{
    //класс определяет какие поля мы получаем в запросе на ИГРЫ
    public class StatisticsDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public RatigStatus status { get; set; } = default!;
    }
}
