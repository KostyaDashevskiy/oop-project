using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //описание полей сущности GameStatistics(столбцы таблицы GameStatistics)
    public class GameStatistics
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int TotalGames { get; set; } = default!;
        public int Wins { get; set; } = default!;
        public int Defeats { get; set; } = default!;
        public int Draws { get; set; } = default!;
    }
}
