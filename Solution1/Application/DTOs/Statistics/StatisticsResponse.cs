using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Statistics
{
    //класс определяет какие поля мы передаем в ответе на ИГРЫ
    public record StatisticsResponse(int Code, int TotalGames, int Wins, int Defeats, int Draws);
}
