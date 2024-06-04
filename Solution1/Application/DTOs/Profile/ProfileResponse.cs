using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Profile
{
    //класс определяет какие поля мы передаем в ответе на ПРОФИЛЬ
     public record ProfileResponse(int Code, string Message, string Email, string Rating, string Wins);

}
