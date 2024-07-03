using Application.Contract.GameProfile;
using Application.DTOs.GameProfile.Rating;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Profile
{

    [Route("api/[controller]")]
    [ApiController]

    public class RatingController : Controller
    {
        private readonly IRating rating;

        public RatingController(IRating rating)
        {
            this.rating = rating;
        }

        //запрос на получение/изменение рейтинга
        [HttpPost("rating")]
        public async Task<ActionResult<RatingResponse>> MMR(RatingDTO ratingDTO)
        {
            var result = await rating.ManipulateMMR(ratingDTO);
            return Ok(result);
        }
    }
}
