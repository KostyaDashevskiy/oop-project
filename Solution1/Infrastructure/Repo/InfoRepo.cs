using Application.Contract;
using Application.DTOs.Info;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo
{
    //класс для обработки запроса по ИНФОРМАЦИИ ПОЛЬЗОВАТЕЛЯ из контроллера
    internal class InfoRepo : IInfo
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public InfoRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск пользователя в таблице Country по имени
        private async Task<UserCountry> FindCountyUserByName(string name) =>
           await appDbContext.Country.FirstOrDefaultAsync(x => x.Name == name);

        //поиск пользователя в таблице Twitch по имени
        private async Task<UserTwitch> FindTwitchUserByName(string name) =>
           await appDbContext.Twitch.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице Info по имени
        private async Task<UserInfo> FindTnfoUserByName(string name) =>
           await appDbContext.Info.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<InfoResponse> GetInfo(InfoDTO infoDTO)
        {
            var getUser = await FindTnfoUserByName(infoDTO.UserName);
            if(getUser == null)
            {
                return new InfoResponse(401, "User doesn't exist", "false", "false");
            }

            var getCountry = await FindCountyUserByName(infoDTO.UserName);
            var getTwitch = await FindTwitchUserByName(infoDTO.UserName);

            getUser.Country = getCountry.Country;
            getUser.Link = getTwitch.Link;

            appDbContext.SaveChangesAsync();

            return new InfoResponse(200, "Success", getUser.Country, getUser.Link);
        }
    }
}
