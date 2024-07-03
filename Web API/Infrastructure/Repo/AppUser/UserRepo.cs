using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Application.DTOs.ApplicationUser.DeleteUser;
using Application.DTOs.ApplicationUser.ChangePassword;
using Application.DTOs.ApplicationUser.Login;
using Application.DTOs.ApplicationUser.RegisterUser;
using Application.Contract.ApplicationUser;

namespace Infrastructure.Repo.AppUser
{
    //класс для обработки запроса по "ПОЛЬЗОВАТЕЛЮ" из контроллера
    internal class UserRepo : IUser
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public UserRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        //поиск пользователя в таблице User по имени
        private async Task<ApplicationUser> FindUserByName(string name) =>
            await appDbContext.Users.FirstOrDefaultAsync(x => x.Name == name);

        //поиск пользователя в таблице User по почте
        private async Task<ApplicationUser> FindUserByMail(string mail) =>
            await appDbContext.Users.FirstOrDefaultAsync(x => x.Email == mail);

        //поиск пользователя в таблице Rating по имени
        private async Task<UserRating> FindRatingUserByName(string name) =>
            await appDbContext.Rating.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице Statistics по имени
        private async Task<GameStatistics> FindStatisticsUserByName(string name) =>
           await appDbContext.Statistics.FirstOrDefaultAsync(x => x.Name == name);

        //поиск по столбцу имени таблицы Profiles
        private async Task<UserProfile> FindProfileUserByName(string name) =>
            await appDbContext.Profiles.FirstOrDefaultAsync(x => x.Name == name);

        //поиск пользователя в таблице Country по имени
        private async Task<UserCountry> FindCountyUserByName(string name) =>
           await appDbContext.Country.FirstOrDefaultAsync(x => x.Name == name);

        //поиск пользователя в таблице Twitch по имени
        private async Task<UserTwitch> FindTwitchUserByName(string name) =>
           await appDbContext.Twitch.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице AboutUsers по имени
        private async Task<AboutUser> FindAboutUserByName(string name) =>
           await appDbContext.AboutUsers.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице Ages по имени
        private async Task<UserAge> FindAgeUserByName(string name) =>
           await appDbContext.Ages.FirstOrDefaultAsync(x => x.UserName == name);

        //поиск пользователя в таблице Info по имени
        private async Task<UserInfo> FindTnfoUserByName(string name) =>
           await appDbContext.Info.FirstOrDefaultAsync(x => x.Name == name);

        //поиск по столбцу имени таблицы Guilds
        private async Task<UserGuild> FindGuildByName(string name) =>
            await appDbContext.Guilds.FirstOrDefaultAsync(x => x.GuildName == name);

        //обработка запроса на вход
        public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO)
        {
            var getUser = await FindUserByName(loginDTO.UserName!);
            if (getUser == null)
            {
                return new LoginResponse(401, "Invalid credentails: incorrect login or password");
            }

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, getUser.Password);
            if (!checkPassword)
            {
                return new LoginResponse(402, "Invalid credentails: incorrect login or password");
            }

            return new LoginResponse(200, "Login successeful", GenerateJWTToken(getUser));

        }

        //генерация токена
        private string GenerateJWTToken(ApplicationUser user)
        {
            var secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentails = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email!)
            };
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentails
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //обработка запроса на регистрацию
        public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var getUserName = await FindUserByName(registerUserDTO.UserName!);
            if (getUserName != null)
            {
                return new RegistrationResponse(401, "Invalid credentails: this Username is already taken");
            }

            var getUserMail = await FindUserByMail(registerUserDTO.Email!);
            if (getUserMail != null)
            {
                return new RegistrationResponse(402, "Invalid credentails: this Email is already taken");
            }

            var newUser = new ApplicationUser()
            {
                Name = registerUserDTO.UserName, 
                Email = registerUserDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
            };

            //добавление пользователя в базу
            await appDbContext.Users.AddAsync(newUser);

            //только что созданный пользователь сразу добавляется в другие базы
            await appDbContext.Rating.AddAsync(new UserRating()
            {
                Id = newUser.Id,
                UserName = newUser.Name,
                Rating = 1000
            });
            await appDbContext.Statistics.AddAsync(new GameStatistics()
            {
                Id = newUser.Id,
                Name = newUser.Name,
                TotalGames = 0,
                Wins = 0,
                Defeats = 0,
                Draws = 0,
            });
            await appDbContext.Profiles.AddAsync(new UserProfile()
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                Rating = "1000",
                Wins = "-",
                Guild = "-"
            });
            await appDbContext.Country.AddAsync(new UserCountry()
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Country = "-"
            });
            await appDbContext.Twitch.AddAsync(new UserTwitch()
            {
                Id = newUser.Id,
                UserName = newUser.Name,
                Link = "-"
            });
            await appDbContext.AboutUsers.AddAsync(new AboutUser()
            {
                Id = newUser.Id,
                UserName = newUser.Name,
                About = ""
            });
            await appDbContext.Ages.AddAsync(new UserAge()
            {
                Id = newUser.Id,
                UserName = newUser.Name,
                Age = null
            });
            await appDbContext.Info.AddAsync(new UserInfo()
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Country = "-",
                Link = "-",
                About = "",
                Age = null
            });

            await appDbContext.SaveChangesAsync();

            return new RegistrationResponse(200, "Registration is successful");
        }

        //обработка запроса на удаление пользователя
        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserDTO deleteUserDTO)
        {
            var getUser = await FindUserByName(deleteUserDTO.UserName!);
            if (getUser == null)
            {
                return new DeleteUserResponse(401, "User not found");
            }

            bool checkPassword = BCrypt.Net.BCrypt.Verify(deleteUserDTO.Password, getUser.Password);
            if (!checkPassword)
            {
                return new DeleteUserResponse(402, "Invalid credentails: incorrect password");
            }

            //удаление пользователя из списка гильдии, если он в ней находится
            var getUserProfile = await FindProfileUserByName(deleteUserDTO.UserName);
            if (getUserProfile.Guild != "-")
            {
                var getGuild = await FindGuildByName(getUserProfile.Guild);
                if (getUserProfile.Name == getGuild.GuildAdmin)
                {
                    return new DeleteUserResponse(403, "User is admin of guild");
                }
                
                getGuild.Members.Remove(getUserProfile.Name);
                getGuild.MembersCount--;
                getGuild.GuildRatirng -= Convert.ToInt32(getUserProfile.Rating);
            }

            //удаляем пользователя из базы
            appDbContext.Users.Remove(getUser);

            //так же пользователь удаляется из других баз
            appDbContext.Rating.Remove(await FindRatingUserByName(deleteUserDTO.UserName));
            appDbContext.Statistics.Remove(await FindStatisticsUserByName(deleteUserDTO.UserName));
            appDbContext.Profiles.Remove(await FindProfileUserByName(deleteUserDTO.UserName));
            appDbContext.Country.Remove(await FindCountyUserByName(deleteUserDTO.UserName));
            appDbContext.Twitch.Remove(await FindTwitchUserByName(deleteUserDTO.UserName));
            appDbContext.Ages.Remove(await FindAgeUserByName(deleteUserDTO.UserName));
            appDbContext.AboutUsers.Remove(await FindAboutUserByName(deleteUserDTO.UserName));
            appDbContext.Info.Remove(await FindTnfoUserByName(deleteUserDTO.UserName));

            await appDbContext.SaveChangesAsync();

            return new DeleteUserResponse(200, "User has been successfully deleted");
        }

        //обработка запроса на смену пароля
        public async Task<ChangePasswordResponse> ChangePasswordAsync(ChangePasswordDTO сhangePasswordDTO)
        {
            var getUser = await FindUserByName(сhangePasswordDTO.UserName!);
            if (getUser == null)
            {
                return new ChangePasswordResponse(401, "User not found");
            }

            bool checkPassword = BCrypt.Net.BCrypt.Verify(сhangePasswordDTO.OldPassword, getUser.Password);
            if (!checkPassword)
            {
                return new ChangePasswordResponse(402, "Invalid credentails: incorrect password");
            }

            getUser.Password = BCrypt.Net.BCrypt.HashPassword(сhangePasswordDTO.NewPassword);

            await appDbContext.SaveChangesAsync();

            return new ChangePasswordResponse(200, "Password changed successfully");
        }
    }
}
