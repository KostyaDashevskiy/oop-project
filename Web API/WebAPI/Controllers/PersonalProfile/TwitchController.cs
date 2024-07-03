using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.Country;
using Application.DTOs.PersonalProfile.Twitch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PersonalProfile
{

    [Route("api/[controller]")]
    [ApiController]

    public class TwitchController : Controller
    {
        private readonly ITwitch twitch;

        public TwitchController(ITwitch twitch)
        {
            this.twitch = twitch;
        }

        //запрос на запись ссылки на Twitch
        [HttpPatch("setTwitch")]
        public async Task<ActionResult<CountryResponse>> SetTwitch(TwitchDTO twitchDTO)
        {
            var result = await twitch.SetTwitch(twitchDTO);
            return Ok(result);
        }
    }
}
