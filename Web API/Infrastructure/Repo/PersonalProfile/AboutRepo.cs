using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.About;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo.PersonalProfile
{
    //класс для обработки запроса по "ИНФОРМАЦИИ О ПОЛЬЗОВАТЕЛЕ" из контроллера
    internal class AboutRepo : IAbout
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public AboutRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск пользователя в таблице AboutUsers по имени
        private async Task<AboutUser> FindAboutUserByName(string name) =>
           await appDbContext.AboutUsers.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице Info по имени
        private async Task<UserInfo> FindTnfoUserByName(string name) =>
           await appDbContext.Info.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<AboutResponse> SetAbout(AboutDTO aboutDTO)
        {
            var getUser = await FindAboutUserByName(aboutDTO.UserName!);
            if (getUser == null)
            {
                return new AboutResponse(401, "User doesn't exist");
            }

            getUser.About = aboutDTO.About;

            var getInfoUser = await FindTnfoUserByName(aboutDTO.UserName!);
            getInfoUser.About = aboutDTO.About;

            appDbContext.SaveChangesAsync();

            return new AboutResponse(200, "Success");
        }
    }
}
