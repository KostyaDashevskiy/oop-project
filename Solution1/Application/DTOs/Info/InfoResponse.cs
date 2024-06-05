namespace Application.DTOs.Info
{
    //класс определяет какие поля мы передаем в ответе на ИНФОРМАЦИЮ О ПОЛЬЗОВАТЕЛЕ
    public record InfoResponse(int Code, string Message, string Country, string TwitchLink);
}
