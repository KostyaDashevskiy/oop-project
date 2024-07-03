using Application.Contract.Guild;
using Application.DTOs.Guild.DeleteGuild;
using Application.DTOs.Guild.DeleteMember;
using Application.DTOs.Guild.EditDescription;
using Application.DTOs.Guild.RegisterGuild;
using Infrastructure.Data;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Guild.GetGuild;

namespace Infrastructure.Repo.Guild
{
    //класс для обработки запроса по "ГИЛЬДИИ" из контроллера
    internal class GuildRepo : IGuild
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public GuildRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск по столбцу имени таблицы Profiles
        private async Task<UserProfile> FindProfileUserByName(string name) =>
            await appDbContext.Profiles.FirstOrDefaultAsync(x => x.Name == name);

        //поиск по столбцу имени таблицы Guilds
        private async Task<UserGuild> FindGuildByName(string name) =>
            await appDbContext.Guilds.FirstOrDefaultAsync(x => x.GuildName == name);

        //поиск по столбцу имени таблицы Rating
        private async Task<UserRating> FindUserRatingByName(string name) =>
            await appDbContext.Rating.FirstOrDefaultAsync(x => x.UserName == name);

        public async Task<DeleteGuildResponse> DeleteGuildAsync(DeleteGuildDTO deleteGuildDTO)
        {
            var getGuild = await FindGuildByName(deleteGuildDTO.GuildName!);
            if (getGuild == null)
            {
                return new DeleteGuildResponse(401, "Such guild doesn't exist");
            }

            if (getGuild.GuildAdmin != deleteGuildDTO.Sender)
            {
                return new DeleteGuildResponse(402, "Not enough rights");
            }

            foreach (var member in getGuild.Members)
            {
                var getMember = await FindProfileUserByName(member);
                getMember.Guild = "-";
            }

            appDbContext.Guilds.Remove(getGuild);

            await appDbContext.SaveChangesAsync();

            return new DeleteGuildResponse(200, "Success");
        }

        public async Task<DeleteGuildMemberResponse> DeleteGuildMember(DeleteGuildMemberDTO deleteGuildMembersDTO)
        {
            var getGuild = await FindGuildByName(deleteGuildMembersDTO.GuildName!);
            if (getGuild == null)
            {
                return new DeleteGuildMemberResponse(401, "Such guild doesn't exist");
            }

            if (getGuild.GuildAdmin != deleteGuildMembersDTO.Sender)
            {
                return new DeleteGuildMemberResponse(402, "Not enough rights");
            }

            var getUserToDelete = await FindProfileUserByName(deleteGuildMembersDTO.UserToDelete);
            if(getUserToDelete == null)
            {
                return new DeleteGuildMemberResponse(403, "No such user");
            }
            else if(getGuild.Members.FirstOrDefault(deleteGuildMembersDTO.UserToDelete) == null)
            {
                return new DeleteGuildMemberResponse(404, "No such member in guild");
            }

            getGuild.Members.Remove(deleteGuildMembersDTO.UserToDelete);
            getGuild.MembersCount--;
            getUserToDelete.Guild = "-";

            await appDbContext.SaveChangesAsync();

            return new DeleteGuildMemberResponse(200, "Success");
        }

        public async Task<EditGuildDescriptionResponse> EditGuildDescriptionAsync(EditGuildDescriptionDTO editGuildDescriptionDTO)
        {
            var getGuild = await FindGuildByName(editGuildDescriptionDTO.GuildName!);
            if (getGuild == null)
            {
                return new EditGuildDescriptionResponse(401, "Such guild doesn't exist");
            }

            if(getGuild.GuildAdmin != editGuildDescriptionDTO.UserName)
            {
                return new EditGuildDescriptionResponse(402, "Not enough rights");
            }

            getGuild.GuildDescription = editGuildDescriptionDTO.Description;

            await appDbContext.SaveChangesAsync();

            return new EditGuildDescriptionResponse(200, "Success");
        }

        public async Task<RegistrationGuildResponse> RegisterGuildAsync(RegistrationGuildDTO registerGuildDTO)
        {
            var getGuild = await FindGuildByName (registerGuildDTO.GuildName!);
            if(getGuild != null)
            {
                return new RegistrationGuildResponse(401, "Guild by that name already exists");
            }

            var getProfile = await FindProfileUserByName(registerGuildDTO.UserName!);
            if (getProfile.Guild != "-")
            {
                return new RegistrationGuildResponse(402, "User is already a member of a guild");
            }

            var getRating = await FindUserRatingByName(registerGuildDTO.UserName);

            var newGuild = new UserGuild()
            {
                GuildName = registerGuildDTO.GuildName,
                MembersCount = 1,
                Members = new List<string> { getProfile.Name },
                GuildAdmin = registerGuildDTO.UserName,
                GuildDescription = "-",
                GuildRatirng = getRating.Rating
            };

            getProfile.Guild = registerGuildDTO.GuildName;

            await appDbContext.Guilds.AddAsync(newGuild);

            await appDbContext.SaveChangesAsync();

            return new RegistrationGuildResponse(200, "Guild created successful");
        }

        public async Task<GetGuildResponse> GetGuild(GetGuildDTO getGuildDTO)
        {
            var getGuild = await FindGuildByName(getGuildDTO.GuildName);
            if(getGuild == null)
            {
                return new GetGuildResponse(401, "Guild doesn't exist", "false", 0, 0, "false", new List<string>(0));
            }

            return new GetGuildResponse(200, "Success", getGuild.GuildName, getGuild.MembersCount,
                getGuild.GuildRatirng, getGuild.GuildAdmin, getGuild.Members);
        }
    }
}
