using Application.DTOs.Rating;
using Application.DTOs.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    //перечисление того, что мы можем сделать с игрой
    public enum GameStatus
    {
        Victory,
        Defeat,
        Draw,
        Show
    }

    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IGames
    {
        Task<StatisticsResponse> ManipulateGames(StatisticsDTO statisticsDTO, GameStatus status);
    }
}
