namespace Application.DTOs.GameProfile.Profile.IsAdminOfGuild
{
    //класс определяет какие поля мы передаем в ответе на "ПРОВЕРКУ НА АДМИНИСТРАТОРА ГИЛЬДИИ"
    public record IsAdminOfGuildResponse(int Code, string Message);
}
