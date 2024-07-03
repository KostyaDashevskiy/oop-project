namespace Application.DTOs.ApplicationUser.Login
{
    //класс определяет какие поля мы передаем в ответе на "ЛОГИН"
    public record LoginResponse(int Code, string Message = null!, string Token = null!);

}
