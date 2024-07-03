namespace Application.DTOs.PersonalProfile.Info
{
    //класс определяет какие поля мы передаем в ответе на "ПЕРСОНАЛЬНУЮ ИНФОРМАЦИЮ О ПОЛЬЗОВАТЕЛЕ"
    public record InfoResponse(int Code, string Message, string Country, string TwitchLink, int? Age, string About);
}
