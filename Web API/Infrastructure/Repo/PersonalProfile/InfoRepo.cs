using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.Info;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo.PersonalProfile
{
    //класс для обработки запроса по "ПЕРСОНАЛЬНОЙ ИНФОРМАЦИИ ПОЛЬЗОВАТЕЛЯ" из контроллера
    internal class InfoRepo : IInfo
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public InfoRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск пользователя в таблице Info по имени
        private async Task<UserInfo> FindTnfoUserByName(string name) =>
           await appDbContext.Info.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<InfoResponse> GetInfo(InfoDTO infoDTO)
        {
            var getUser = await FindTnfoUserByName(infoDTO.UserName);
            if (getUser == null)
            {
                return new InfoResponse(401, "User doesn't exist", "false", "false", -1, "false");
            }

            return new InfoResponse(200, "Success", getUser.Country, getUser.Link, getUser.Age, getUser.About);
        }
    }
}
