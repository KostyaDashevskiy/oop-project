using Domain.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.GameProfile.Rating;
using Application.Contract.GameProfile;

namespace Infrastructure.Repo.GameProfile
{
    //класс для обработки запроса по "РЕЙТИНГУ" из контроллера
    internal class RatingRepo : IRating
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public RatingRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск по столбцу имени таблицы Rating
        private async Task<UserRating> FindUserByName(string name) =>
            await appDbContext.Rating.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск по столбцу имени таблицы Statistics
        private async Task<GameStatistics> FindStatUserByName(string name) =>
            await appDbContext.Statistics.FirstOrDefaultAsync(x => x.Name == name);

        //поиск по столбцу имени таблицы Profiles
        private async Task<UserProfile> FindProfileUserByName(string name) =>
            await appDbContext.Profiles.FirstOrDefaultAsync(x => x.Name == name);

        //поиск по столбцу имени таблицы Guilds
        private async Task<UserGuild> FindGuildByName(string name) =>
            await appDbContext.Guilds.FirstOrDefaultAsync(x => x.GuildName == name);

        //обработка запроса по рейтингу
        public async Task<RatingResponse> ManipulateMMR(RatingDTO ratingDTO)
        {
            int ratingDiff = 0;

            var getUser = await FindUserByName(ratingDTO.UserName);
            if (getUser == null)
            {
                return new RatingResponse(401, "No user with this username was found", null);
            }

            var getUserStats = await FindStatUserByName(ratingDTO.UserName);
            getUserStats.TotalGames++;

            switch (ratingDTO.status)
            {
                case RatigStatus.Victory:
                    ratingDiff = (2000 - getUser.Rating) / 40;
                    getUserStats.Wins++;
                    break;
                case RatigStatus.Defeat:
                    ratingDiff = -getUser.Rating / 40;
                    getUserStats.Defeats++;
                    break;
                case RatigStatus.Draw:
                    getUserStats.Draws++;
                    break;
                default:
                    break;
            }

            getUser.Rating += ratingDiff;

            var getProfileUser = await FindProfileUserByName(ratingDTO.UserName);
            if(getProfileUser.Guild != "-")
            {
                var getGuild = await FindGuildByName(getProfileUser.Guild);
                getGuild.GuildRatirng += ratingDiff; 
            }

            await appDbContext.SaveChangesAsync();

            return new RatingResponse(200, "Success", getUser.Rating.ToString());
        }
    }
}
