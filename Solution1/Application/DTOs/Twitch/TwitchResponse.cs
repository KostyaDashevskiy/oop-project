using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Twitch
{
    //класс определяет какие поля мы получаем в запросе на ТВИТЧ
    public record TwitchResponse(int Code, string Message);
}
