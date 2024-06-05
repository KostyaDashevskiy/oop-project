using Application.Contract;
using Application.DTOs.Country;
using Application.DTOs.Twitch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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

        //запрос на запись страны
        [HttpPost("setTwitch")]
        public async Task<ActionResult<CountryResponse>> SetTwitch(TwitchDTO twitchDTO)
        {
            var result = await twitch.SetTwitch(twitchDTO);
            return Ok(result);
        }
    }
}
