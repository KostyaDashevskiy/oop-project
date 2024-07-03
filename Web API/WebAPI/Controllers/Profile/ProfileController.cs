using Application.Contract.GameProfile;
using Application.DTOs.GameProfile.Profile.EntryGuild;
using Application.DTOs.GameProfile.Profile.GetProfile;
using Application.DTOs.GameProfile.Profile.IsAdminOfGuild;
using Application.DTOs.GameProfile.Profile.QuitGuild;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Profile
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

        //запрос на получение игрового профиля пользователя
        [HttpGet("getProfile")]
        public async Task<ActionResult<ProfileResponse>> GetProfileInfo([FromQuery] ProfileDTO profileDTO)
        {
            var result = await profile.GetProfile(profileDTO);
            return Ok(result);
        }

        //запрос на проверку является ли пользователь админом гильдии
        [HttpGet("IsAdminOfGuild")]
        public async Task<ActionResult<IsAdminOfGuildResponse>> IsAdmin([FromQuery] IsAdminOfGuildDTO isAdminOfGuildDTO)
        {
            var result = await profile.IsAdminOfGuild(isAdminOfGuildDTO);
            return Ok(result);
        }

        //запрос на присоединение к гильдии
        [HttpPatch("JoinGuild")]
        public async Task<ActionResult<EntryGuildResponse>> JoinGuild(EntryGuildDTO entryGuildDTO)
        {
            var result = await profile.EntryGuild(entryGuildDTO);
            return Ok(result);
        }

        //запрос на выход из гильдии
        [HttpPatch("ResignGuild")]
        public async Task<ActionResult<QuitGuildResponse>> ResignGuild(QuitGuildDTO quitGuildDTO)
        {
            var result = await profile.QuitGuild(quitGuildDTO);
            return Ok(result);
        }
    }
}
