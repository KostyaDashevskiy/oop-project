using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Country
{
    //класс определяет какие поля мы получаем в запросе на СТРАНУ
    public class CountryDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Country { get; set; } = default!;
    }
}
