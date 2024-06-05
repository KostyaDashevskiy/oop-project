namespace Application.DTOs.Statistics
{
    //класс определяет какие поля мы передаем в ответе на ИГРЫ
    public record StatisticsResponse(int Code, int TotalGames, int Wins, int Defeats, int Draws);
}
