namespace Application.DTOs.GameProfile.Profile.QuitGuild
{
    //класс определяет какие поля мы передаем в ответе на "ВЫХОД ИЗ ГИЛЬДИИ"
    public record QuitGuildResponse(int Code, string Message);
}
