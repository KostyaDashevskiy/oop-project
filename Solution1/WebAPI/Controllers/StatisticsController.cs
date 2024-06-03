using Microsoft.AspNetCore.Mvc;
using Application.Contract;
using Application.DTOs.Statistics;
using Application.DTOs.Rating;

namespace WebAPI.Controllers
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

        [HttpPost("statistics")]
        public async Task<ActionResult<StatisticsResponse>> GetStatistics(StatisticsDTO statisticsDTO, GameStatus status)
        {
            var result = await statistics.ManipulateGames(statisticsDTO, status);
            return Ok(result);
        }
    }
}
