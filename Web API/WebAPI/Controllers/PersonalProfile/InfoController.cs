using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.About;
using Application.DTOs.PersonalProfile.Age;
using Application.DTOs.PersonalProfile.Country;
using Application.DTOs.PersonalProfile.Info;
using Application.DTOs.PersonalProfile.Twitch;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace WebAPI.Controllers.PersonalProfile
{

    [Route("api/[controller]")]
    [ApiController]

    public class InfoController : Controller
    {
        private readonly IInfo info;

        public InfoController(IInfo info)
        {
            this.info = info;
        }

        //запрос на получение персональной информации о пользователе
        [HttpGet("getInfo")]
        public async Task<ActionResult<InfoResponse>> GetInfo([FromQuery] InfoDTO infoDTO)
        {
            var result = await info.GetInfo(infoDTO);
            return Ok(result);
        }

        //запрос на запись ссылки на Twitch
        [HttpPatch("setTwitch")]
        public async Task<ActionResult<TwitchResponse>> SetTwitch(TwitchDTO twitchDTO)
        {
            var result = await info.SetTwitch(twitchDTO);
            return Ok(result);
        }

        //запрос на запись страны
        [HttpPatch("setCountry")]
        public async Task<ActionResult<CountryResponse>> SetCountry(CountryDTO countryDTO)
        {
            var result = await info.SetCountry(countryDTO);
            return Ok(result);
        }

        //запрос на запись ВОЗРАСТЕ
        [HttpPatch("setAge")]
        public async Task<ActionResult<AgeResponse>> SetAge(AgeDTO ageDTO)
        {
            var result = await info.SetAge(ageDTO);
            return Ok(result);
        }

        //запрос на запись О СЕБЕ
        [HttpPatch("setAbout")]
        public async Task<ActionResult<AboutResponse>> SetAbout(AboutDTO aboutDTO)
        {
            var result = await info.SetAbout(aboutDTO);
            return Ok(result);
        }
    }
}
