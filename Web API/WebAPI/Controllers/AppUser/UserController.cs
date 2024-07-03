using Application.Contract.ApplicationUser;
using Application.DTOs.ApplicationUser.ChangePassword;
using Application.DTOs.ApplicationUser.DeleteUser;
using Application.DTOs.ApplicationUser.Login;
using Application.DTOs.ApplicationUser.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.AppUser
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
            var result = await user.LoginUserAsync(loginDTO);
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
        [HttpPatch("changePassword")]
        public async Task<ActionResult<ChangePasswordResponse>> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var result = await user.ChangePasswordAsync(changePasswordDTO);
            return Ok(result);
        }
    }
}
