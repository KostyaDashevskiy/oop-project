using Application.Contract;
using Application.DTOs.Country;
using Application.DTOs.Profile;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Controllers
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
        [HttpPost("setCountry")]
        public async Task<ActionResult<CountryResponse>> SetCountry(CountryDTO countryDTO)
        {
            var result = await country.SetCountry(countryDTO);
            return Ok(result);
        }
    }
}
