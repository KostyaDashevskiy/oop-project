﻿using Application.Contract.GameProfile;
using Application.DTOs.GameProfile.Statistics;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo.GameProfile
{
    //класс для обработки запроса по "СТАТИСТИКЕ" из контроллера
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

        public async Task<StatisticsResponse> GetStatistics(StatisticsDTO statisticsDTO)
        {
            var getUser = await FindUserByName(statisticsDTO.UserName);
            if (getUser == null)
            {
                return new StatisticsResponse(401, "User not found", 0, 0, 0, 0);
            }

            return new StatisticsResponse(200, "Success", getUser.TotalGames, getUser.Wins, getUser.Defeats, getUser.Draws);
        }
    }
}
