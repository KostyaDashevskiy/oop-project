using Application.Contract;
using Application.DTOs.Country;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    internal class CountryRepo : ICountry
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public CountryRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск пользователя в таблице Country по имени
        private async Task<UserCountry> FindCountyUserByName(string name) =>
           await appDbContext.Country.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<CountryResponse> SetCountry(CountryDTO countryDTO)
        {
            var getUser = await FindCountyUserByName(countryDTO.UserName!);
            if(getUser == null)
            {
                return new CountryResponse(401, "User doesn't exist");
            }

            getUser.Country = countryDTO.Country;

            appDbContext.SaveChanges();

            return new CountryResponse(200, "Success");
        }
    }
}
