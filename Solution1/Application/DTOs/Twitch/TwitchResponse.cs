namespace Application.DTOs.Twitch
{
    //класс определяет какие поля мы получаем в запросе на ТВИТЧ
    public record TwitchResponse(int Code, string Message);
}
