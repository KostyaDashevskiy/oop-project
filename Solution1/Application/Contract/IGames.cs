using Application.DTOs.Statistics;

namespace Application.Contract
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IGames
    {
        Task<StatisticsResponse> GetStatistics(StatisticsDTO statisticsDTO);
    }
}
