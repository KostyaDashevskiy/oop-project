using Application.Contract.PersonalProfile;
using Application.DTOs.PersonalProfile.Age;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo.PersonalProfile
{
    //класс для обработки запроса по "ВОЗРАСТУ" из контроллера
    internal class AgeRepo : IAge
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public AgeRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск пользователя в таблице Ages по имени
        private async Task<UserAge> FindAgeUserByName(string name) =>
           await appDbContext.Ages.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице Info по имени
        private async Task<UserInfo> FindTnfoUserByName(string name) =>
           await appDbContext.Info.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<AgeResponse> SetAge(AgeDTO ageDTO)
        {
            var getUser = await FindAgeUserByName(ageDTO.UserName!);
            if (getUser == null)
            {
                return new AgeResponse(401, "User doesn't exist");
            }

            getUser.Age = ageDTO.Age;

            var getInfoUser = await FindTnfoUserByName(ageDTO.UserName!);
            getInfoUser.Age = ageDTO.Age;

            appDbContext.SaveChangesAsync();

            return new AgeResponse(200, "Success");
        }
    }
}
