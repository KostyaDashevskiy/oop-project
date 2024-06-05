using Application.Contract;
using Application.DTOs.Twitch;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo
{
    //класс для обработки запроса по ТВИЧУ из контроллера
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

        public async Task<TwitchResponse> SetTwitch(TwitchDTO twitchDTO)
        {
            var getUser = await FindTwitchUserByName(twitchDTO.UserName!);
            if (getUser == null)
            {
                return new TwitchResponse(401, "User doesn't exist");
            }

            getUser.Link = twitchDTO.TwitchLink;

            appDbContext.SaveChangesAsync();

            return new TwitchResponse(200, "Success");
        }
    }
}
