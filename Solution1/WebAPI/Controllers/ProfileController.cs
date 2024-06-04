using Application.Contract;
using Application.DTOs.Profile;
using Application.DTOs.Rating;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProfileController : Controller
    {

        private readonly IProfile profile;

        public ProfileController(IProfile profile)
        {
            this.profile = profile;
        }

        //запрос на получение профиля
        [HttpPost("getProfile")]
        public async Task<ActionResult<ProfileResponse>> GetProfileInfo(ProfileDTO profileDTO)
        {
            var result = await profile.GetProfile(profileDTO);
            return Ok(result);
        }
    }
}
