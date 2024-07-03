using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.About;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PersonalProfile
{
    [Route("api/[controller]")]
    [ApiController]

    public class AboutController : Controller
    {
        private readonly IAbout about;

        public AboutController(IAbout about)
        {
            this.about = about;
        }

        //запрос на запись О СЕБЕ
        [HttpPatch("setAbout")]
        public async Task<ActionResult<AboutResponse>> SetAbout(AboutDTO aboutDTO)
        {
            var result = await about.SetAbout(aboutDTO);
            return Ok(result);
        }
    }
}
