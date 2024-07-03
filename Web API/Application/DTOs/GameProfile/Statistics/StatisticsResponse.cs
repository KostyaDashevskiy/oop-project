namespace Application.DTOs.GameProfile.Statistics
{
    //класс определяет какие поля мы передаем в ответе на "СТАТИСТИКУ ИГР"
    public record StatisticsResponse(int Code, string Message, int TotalGames, int Wins, int Defeats, int Draws);
}
