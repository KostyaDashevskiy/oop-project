using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Info
{
    //класс определяет какие поля мы передаем в ответе на ИНФОРМАЦИЮ О ПОЛЬЗОВАТЕЛЕ
    public record InfoResponse(int Code, string Message, string Country, string TwitchLink);
}
