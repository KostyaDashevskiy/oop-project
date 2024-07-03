namespace Application.DTOs.Guild.RegisterGuild
{
    //класс определяет какие поля мы передаем в ответе на "СОЗДАНИЕ ГИЛЬДИИ"
    public record RegistrationGuildResponse(int Code, string Message);
}
