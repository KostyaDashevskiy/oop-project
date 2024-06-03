using Application.Contract;
using Application.DTOs.Rating;
using Application.DTOs.Statistics;
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
    internal class StatisticsRepo : IGames
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public StatisticsRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск по столбцу имени таблицы Statistics
        private async Task<GameStatistics> FindUserByName(string name) =>
            await appDbContext.Statistics.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<StatisticsResponse> ManipulateGames(StatisticsDTO statisticsDTO, GameStatus status)
        {
            var getUser = await FindUserByName(statisticsDTO.UserName);
            if (getUser == null)
            {
                return new StatisticsResponse(401, 0, 0, 0, 0);
            }

            getUser.TotalGames++;

            switch (status)
            {
                case GameStatus.Victory:
                    getUser.Wins++;
                    break;
                case GameStatus.Defeat:
                    getUser.Defeats++;
                    break;
                case GameStatus.Draw:
                    getUser.Draws++;
                    break;
                default:
                    break;
            }

            appDbContext.SaveChanges();

            return new StatisticsResponse(200, getUser.TotalGames, getUser.Wins, getUser.Defeats, getUser.Draws);
        }
    }
}
