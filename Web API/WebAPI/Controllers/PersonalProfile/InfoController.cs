using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.Info;
using Microsoft.AspNetCore.Mvc;

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
    }
}
