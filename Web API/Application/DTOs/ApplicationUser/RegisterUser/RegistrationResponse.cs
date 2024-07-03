namespace Application.DTOs.ApplicationUser.RegisterUser
{
    //класс определяет какие поля мы передаем в ответе на "РЕГИСТРАЦИЮ"
    public record RegistrationResponse(int Code, string Message = null!);

}
