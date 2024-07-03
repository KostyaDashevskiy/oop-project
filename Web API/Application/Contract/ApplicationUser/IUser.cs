using Application.DTOs.ApplicationUser.ChangePassword;
using Application.DTOs.ApplicationUser.DeleteUser;
using Application.DTOs.ApplicationUser.Login;
using Application.DTOs.ApplicationUser.RegisterUser;

namespace Application.Contract.ApplicationUser
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IUser
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);
        Task<DeleteUserResponse> DeleteUserAsync(DeleteUserDTO deleteUserDTO);
        Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    }
}
