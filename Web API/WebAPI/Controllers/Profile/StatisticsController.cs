using Microsoft.AspNetCore.Mvc;
using Application.DTOs.GameProfile.Statistics;
using Application.Contract.GameProfile;

namespace WebAPI.Controllers.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        private readonly IGames statistics;

        public StatisticsController(IGames statistics)
        {
            this.statistics = statistics;
        }

        //запрос на получение игровой статистики пользователя
        [HttpGet("getStatistics")]
        public async Task<ActionResult<StatisticsResponse>> GetStatistics([FromQuery] StatisticsDTO statisticsDTO)
        {
            var result = await statistics.GetStatistics(statisticsDTO);
            return Ok(result);
        }
    }
}
