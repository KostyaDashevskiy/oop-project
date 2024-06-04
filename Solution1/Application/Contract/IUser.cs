using Application.DTOs.ChangePassword;
using Application.DTOs.DeleteUser;
using Application.DTOs.Login;
using Application.DTOs.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
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
