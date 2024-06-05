namespace Application.DTOs.DeleteUser
{
    //класс определяет какие поля мы передаем в ответе на УДАЛЕНИЕ ПОЛЬЗОВАТЕЛЯ
    public record DeleteUserResponse(int Code, string Message);
}
