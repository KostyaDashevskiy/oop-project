using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.Age;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PersonalProfile
{
    [Route("api/[controller]")]
    [ApiController]

    public class AgeController : Controller
    {
        private readonly IAge age;

        public AgeController(IAge age)
        {
            this.age = age;
        }

        //запрос на запись ВОЗРАСТЕ
        [HttpPatch("setAge")]
        public async Task<ActionResult<AgeResponse>> SetAge(AgeDTO ageDTO)
        {
            var result = await age.SetAge(ageDTO);
            return Ok(result);
        }
    }
}
