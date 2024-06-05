using Microsoft.AspNetCore.Mvc;
using Application.Contract;
using Application.DTOs.Statistics;

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

        [HttpPost("getStatistics")]
        public async Task<ActionResult<StatisticsResponse>> GetStatistics(StatisticsDTO statisticsDTO)
        {
            var result = await statistics.GetStatistics(statisticsDTO);
            return Ok(result);
        }
    }
}
