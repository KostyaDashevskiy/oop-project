using Application.Contract;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("login")]//запрос на вход
        public async Task<ActionResult<LoginResponse>> LogUserIn(LoginDTO loginDTO)
        {
            var result= await user.LoginUserAsync(loginDTO);//->Applicaton\DTOs\LoginDTO
            return Ok(result);//->Applicaton\DTOs\LoginResponse
        }

        [HttpPost("register")]//запрос на регистрацию
        public async Task<ActionResult<RegistrationResponse>> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = await user.RegisterUserAsync(registerUserDTO);//->Applicaton\DTOs\
            return Ok(result);//->Applicaton\DTOs\RegistrationResponse
        }

        [HttpDelete("deleteUser")]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser(DeleteUserDTO deleteUserDTO)
        {
            var result = await user.DeleteUserAsync(deleteUserDTO);
            return Ok(result);
        }
    }
}
