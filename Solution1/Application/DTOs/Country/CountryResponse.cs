using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Country
{
    //класс определяет какие поля мы передаем в ответе на СТРАНУ
    public record CountryResponse(int Code, string Message);
}
