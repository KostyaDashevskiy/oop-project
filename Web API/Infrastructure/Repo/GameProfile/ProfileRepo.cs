using Application.Contract.GameProfile;
using Application.DTOs.GameProfile.Profile.EntryGuild;
using Application.DTOs.GameProfile.Profile.QuitGuild;
using Application.DTOs.GameProfile.Profile.GetProfile;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.DTOs.GameProfile.Profile.IsAdminOfGuild;

namespace Infrastructure.Repo.GameProfile
{
    //класс для обработки запроса по "ПРОФИЛЮ" из контроллера
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

        //поиск по столбцу имени таблицы Guilds
        private async Task<UserGuild> FindGuildByName(string name) =>
            await appDbContext.Guilds.FirstOrDefaultAsync(x => x.GuildName == name);

        public async Task<ProfileResponse> GetProfile(ProfileDTO profileDTO)
        {
            var getUser = await FindProfileUserByName(profileDTO.UserName);
            if (getUser == null)
            {
                return new ProfileResponse(401, "User doesn't exist", "false", "false", "false", "false");
            }

            var getEmail = await FindUserByName(profileDTO.UserName);
            var getRating = await FindRatingUserByName(profileDTO.UserName);
            var getWins = await FindStatisticsUserByName(profileDTO.UserName);

            getUser.Email = getEmail.Email;
            getUser.Rating = getRating.Rating.ToString();
            getUser.Wins = getWins.Wins.ToString();

            return new ProfileResponse(200, "Success", getUser.Email, getUser.Rating, getUser.Wins, getUser.Guild);
        }

        public async Task<EntryGuildResponse> EntryGuild(EntryGuildDTO entryGuildDTO)
        {
            var getUser = await FindProfileUserByName(entryGuildDTO.UserName);
            if(getUser == null)
            {
                return new EntryGuildResponse(401, "No such user");
            }

            var getGuild = await FindGuildByName(entryGuildDTO.GuildName);
            if(getGuild == null)
            {
                return new EntryGuildResponse(402, "No such guild");
            }

            if(getGuild.MembersCount >= 50)
            {
                return new EntryGuildResponse(403, "Guild is already maxed out");
            }

            if(getUser.Guild != "-")
            {
                return new EntryGuildResponse(404, "User already has a guild");
            }

            var getRating = await FindRatingUserByName(entryGuildDTO.UserName);

            getGuild.MembersCount++;
            getGuild.Members.Add(entryGuildDTO.UserName);
            getGuild.GuildRatirng += getRating.Rating;
            getUser.Guild = entryGuildDTO.GuildName;

            await appDbContext.SaveChangesAsync();

            return new EntryGuildResponse(200, "Success");
        }

        public async Task<QuitGuildResponse> QuitGuild(QuitGuildDTO quitGuildDTO)
        {
            var getUser = await FindProfileUserByName(quitGuildDTO.UserName);
            if (getUser == null)
            {
                return new QuitGuildResponse(401, "No such user");
            }

            var getGuild = await FindGuildByName(quitGuildDTO.GuildName);
            if (getGuild == null)
            {
                return new QuitGuildResponse(402, "No such guild");
            }

            if (getGuild.MembersCount <= 1)
            {
                return new QuitGuildResponse(403, "Single member user");
            }

            if (getUser.Guild != quitGuildDTO.GuildName)
            {
                return new QuitGuildResponse(404, "User isn't member of this guild");
            }

            var getRating = await FindRatingUserByName(quitGuildDTO.UserName);

            getGuild.MembersCount--;
            getGuild.Members.Remove(quitGuildDTO.UserName);
            getGuild.GuildRatirng -= getRating.Rating;
            getUser.Guild = "-";

            await appDbContext.SaveChangesAsync();

            return new QuitGuildResponse(200, "Success");
        }

        public async Task<IsAdminOfGuildResponse> IsAdminOfGuild(IsAdminOfGuildDTO isAdminOfGuild)
        {
            var getUser = await FindProfileUserByName(isAdminOfGuild.UserName);
            if (getUser == null)
            {
                return new IsAdminOfGuildResponse(401, "No such user");
            }

            var getGuild = await FindGuildByName(isAdminOfGuild.GuildName);
            if(getGuild == null)
            {
                return new IsAdminOfGuildResponse(402, "No such guild");
            }

            if(getGuild.GuildAdmin == isAdminOfGuild.UserName)
            {
                return new IsAdminOfGuildResponse(201, "Admin");
            }

            return new IsAdminOfGuildResponse(202, "Not admin");
        }
    }
}
