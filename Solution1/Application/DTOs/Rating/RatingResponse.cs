using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Rating
{
    //класс определяет какие поля мы передаем в ответе на РЕЙТИНГ
    public record RatingResponse(int code, string Mmr);
}
