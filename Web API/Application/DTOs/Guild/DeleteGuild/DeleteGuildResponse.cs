namespace Application.DTOs.Guild.DeleteGuild
{
    //класс определяет какие поля мы передаем в ответе на "УДАЛЕНИЕ ГИЛЬДИИ"
    public record DeleteGuildResponse(int Code, string Message);
}
