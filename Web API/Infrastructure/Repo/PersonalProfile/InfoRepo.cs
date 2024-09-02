using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.About;
using Application.DTOs.PersonalProfile.Age;
using Application.DTOs.PersonalProfile.Country;
using Application.DTOs.PersonalProfile.Info;
using Application.DTOs.PersonalProfile.Twitch;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo.PersonalProfile
{
    //класс для обработки запросов по "ПЕРСОНАЛЬНОЙ ИНФОРМАЦИИ ПОЛЬЗОВАТЕЛЯ" из контроллера
    internal class InfoRepo : IInfo
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public InfoRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск пользователя в таблице Info по имени
        private async Task<UserInfo> FindTnfoUserByName(string name) =>
           await appDbContext.Info.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<InfoResponse> GetInfo(InfoDTO infoDTO)
        {
            var getUser = await FindTnfoUserByName(infoDTO.UserName);
            if (getUser == null)
            {
                return new InfoResponse(401, "User doesn't exist", "false", "false", -1, "false");
            }

            return new InfoResponse(200, "Success", getUser.Country, getUser.Link, getUser.Age, getUser.About);
        }

        public async Task<TwitchResponse> SetTwitch(TwitchDTO twitchDTO)
        {
            var getUser = await FindTnfoUserByName(twitchDTO.UserName!);
            if (getUser == null)
            {
                return new TwitchResponse(401, "User doesn't exist");
            }

            getUser.Link = twitchDTO.TwitchLink;

            await appDbContext.SaveChangesAsync();

            return new TwitchResponse(200, "Success");
        }

        public async Task<CountryResponse> SetCountry(CountryDTO countryDTO)
        {
            var getUser = await FindTnfoUserByName(countryDTO.UserName!);
            if (getUser == null)
            {
                return new CountryResponse(401, "User doesn't exist");
            }

            getUser.Country = countryDTO.Country;

            await appDbContext.SaveChangesAsync();

            return new CountryResponse(200, "Success");
        }

        public async Task<AgeResponse> SetAge(AgeDTO ageDTO)
        {
            var getUser = await FindTnfoUserByName(ageDTO.UserName!);
            if (getUser == null)
            {
                return new AgeResponse(401, "User doesn't exist");
            }

            getUser.Age = ageDTO.Age;

            await appDbContext.SaveChangesAsync();

            return new AgeResponse(200, "Success");
        }

        public async Task<AboutResponse> SetAbout(AboutDTO aboutDTO)
        {
            var getUser = await FindTnfoUserByName(aboutDTO.UserName!);
            if (getUser == null)
            {
                return new AboutResponse(401, "User doesn't exist");
            }

            getUser.About = aboutDTO.About;

            await appDbContext.SaveChangesAsync();

            return new AboutResponse(200, "Success");
        }
    }
}
