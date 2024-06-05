using Application.Contract;
using Application.DTOs.Info;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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

        //запрос на запись страны
        [HttpPost("getInfo")]
        public async Task<ActionResult<InfoResponse>> GetInfo(InfoDTO infoDTO)
        {
            var result = await info.GetInfo(infoDTO);
            return Ok(result);
        }
    }
}
