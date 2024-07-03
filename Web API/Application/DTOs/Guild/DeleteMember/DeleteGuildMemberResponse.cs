namespace Application.DTOs.Guild.DeleteMember
{
    //класс определяет какие поля мы передаем в ответе на "УДАЛЕНИЕ ЧЛЕНА ГИЛЬДИИ"
    public record DeleteGuildMemberResponse(int Code, string Message);
}
