namespace Application.DTOs.GameProfile.Profile.GetProfile
{
    //класс определяет какие поля мы передаем в ответе на "ПРОФИЛЬ"
    public record ProfileResponse(int Code, string Message, string Email, string Rating, string Wins, string GuildName);

}
