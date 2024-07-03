using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.Country;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.PersonalProfile
{

    [Route("api/[controller]")]
    [ApiController]

    public class CountryController : Controller
    {
        private readonly ICountry country;

        public CountryController(ICountry country)
        {
            this.country = country;
        }

        //запрос на запись страны
        [HttpPatch("setCountry")]
        public async Task<ActionResult<CountryResponse>> SetCountry(CountryDTO countryDTO)
        {
            var result = await country.SetCountry(countryDTO);
            return Ok(result);
        }
    }
}
