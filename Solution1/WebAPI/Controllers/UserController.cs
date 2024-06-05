using Application.Contract;
using Application.DTOs.ChangePassword;
using Application.DTOs.DeleteUser;
using Application.DTOs.Login;
using Application.DTOs.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;
        public UserController(IUser user)
        {
            this.user = user;
        }

        //запрос на логин
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LogUserIn(LoginDTO loginDTO)
        {
            var result= await user.LoginUserAsync(loginDTO);
            return Ok(result);
        }

        //запрос на регистрацию
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = await user.RegisterUserAsync(registerUserDTO);
            return Ok(result);
        }

        //запрос на удаление пользователя
        [HttpDelete("deleteUser")]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser(DeleteUserDTO deleteUserDTO)
        {
            var result = await user.DeleteUserAsync(deleteUserDTO);
            return Ok(result);
        }

        //запрос на смену пароля
        [HttpPost("changePassword")]
        public async Task<ActionResult<ChangePasswordResponse>> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var result = await user.ChangePasswordAsync(changePasswordDTO);
            return Ok(result);
        }
    }
}
