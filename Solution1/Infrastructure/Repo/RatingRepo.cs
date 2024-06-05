using System;
using Application.Contract;
using Domain.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Rating;

namespace Infrastructure.Repo
{
    //класс для обработки запроса по РЕЙТИНГУ из контроллера
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

        //обработка запроса по рейтингу
        public async Task<RatingResponse> ManipulateMMR(RatingDTO ratingDTO, RatigStatus status)
        {
            var getUser = await FindUserByName(ratingDTO.UserName);
            if (getUser == null)
            {
                return new RatingResponse(401, "No user with this username was found");
            }

            var getUserStats = await FindStatUserByName(ratingDTO.UserName);
            getUserStats.TotalGames++;

            switch (status)
            {
                case RatigStatus.Victory:
                    getUser.Rating += (2000 - getUser.Rating) / 40;
                    getUserStats.Wins++;
                    break;
                case RatigStatus.Defeat:
                    getUser.Rating -= getUser.Rating / 40;
                    getUserStats.Defeats++;
                    break;
                case RatigStatus.Draw:
                    getUserStats.Draws++;
                    break;
                default:
                    break;
            }

            appDbContext.SaveChangesAsync();

            return new RatingResponse(200, getUser.Rating.ToString());
        }
    }
}
