using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.Twitch;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo.PersonalProfile
{
    //класс для обработки запроса по "ТВИЧУ" из контроллера
    internal class TwitchRepo : ITwitch
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public TwitchRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск пользователя в таблице Twitch по имени
        private async Task<UserTwitch> FindTwitchUserByName(string name) =>
           await appDbContext.Twitch.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице Info по имени
        private async Task<UserInfo> FindTnfoUserByName(string name) =>
           await appDbContext.Info.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<TwitchResponse> SetTwitch(TwitchDTO twitchDTO)
        {
            var getUser = await FindTwitchUserByName(twitchDTO.UserName!);
            if (getUser == null)
            {
                return new TwitchResponse(401, "User doesn't exist");
            }

            getUser.Link = twitchDTO.TwitchLink;

            var getInfoUser = await FindTnfoUserByName(twitchDTO.UserName!);
            getInfoUser.Link = twitchDTO.TwitchLink;

            appDbContext.SaveChangesAsync();

            return new TwitchResponse(200, "Success");
        }
    }
}
