using Application.Contract;
using Application.DTOs.Profile;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo
{
    //класс для обработки запроса по ПРОФИЛЮ из контроллера
    internal class ProfileRepo : IProfile
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public ProfileRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск по столбцу имени таблицы Profiles
        private async Task<UserProfile> FindProfileUserByName(string name) =>
            await appDbContext.Profiles.FirstOrDefaultAsync(x => x.Name == name);

        //поиск пользователя в таблице User по имени
        private async Task<ApplicationUser> FindUserByName(string name) =>
            await appDbContext.Users.FirstOrDefaultAsync(x => x.Name == name);

        //поиск пользователя в таблице Rating по имени
        private async Task<UserRating> FindRatingUserByName(string name) =>
            await appDbContext.Rating.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице Statistics по имени
        private async Task<GameStatistics> FindStatisticsUserByName(string name) =>
           await appDbContext.Statistics.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<ProfileResponse> GetProfile(ProfileDTO profileDTO)
        {
            var getUser = await FindProfileUserByName(profileDTO.UserName);
            if (getUser == null)
            {
                return new ProfileResponse(401, "User doesn't exist", "false", "false", "false");
            }

            var getEmail = await FindUserByName(profileDTO.UserName);
            var getRating = await FindRatingUserByName(profileDTO.UserName);
            var getWins = await FindStatisticsUserByName(profileDTO.UserName);

            getUser.Email = getEmail.Email;
            getUser.Rating = getRating.Rating.ToString();
            getUser.Wins = getWins.Wins.ToString();

            return new ProfileResponse(200, "Success", getUser.Email, getUser.Rating, getUser.Wins);
        }

    }
}
