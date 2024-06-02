using Application.Contract;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Http;

namespace Infrastructure.Repo
{
    internal class UserRepo : IUser
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public UserRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO)//здесь выполняется вход
        {
            var getUser = await FindUserByName(loginDTO.Name!);
            if (getUser == null)
            {
                return new LoginResponse(401, "Invalid credentails: incorrect login or password"); //пользователь не найден
            }

            return new LoginResponse(200, "Login successeful", GenerateJWTToken(getUser));//успешная регистрация

        }

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
                expires: DateTime.Now.AddDays(5),
                signingCredentials: credentails
                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ApplicationUser> FindUserByName(string name) =>
            await appDbContext.Users.FirstOrDefaultAsync(x => x.Name == name);

        private async Task<ApplicationUser> FindUserByMail(string mail) =>
            await appDbContext.Users.FirstOrDefaultAsync(x => x.Email == mail);

        public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var getUserName = await FindUserByName(registerUserDTO.Name!);
            if(getUserName != null) 
            {
                return new RegistrationResponse(401, "Invalid credentails: this Username is already taken");//пользователь уже есть в базе
            }

            var getUserMail = await FindUserByMail(registerUserDTO.Email!);
            if (getUserMail != null)
            {
                return new RegistrationResponse(402, "Invalid credentails: this Email is already taken");//пользователь уже есть в базе
            }

            var newUser = new ApplicationUser()
            {
                Name = registerUserDTO.Name,
                Email = registerUserDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
            };

            appDbContext.Users.Add(newUser);

            appDbContext.Rating.Add(new UserRating()
            {
                Id = newUser.Id,
                UserName = newUser.Name,
                Rating = 1000
            });
            await appDbContext.SaveChangesAsync();
            return new RegistrationResponse(200, "Registration is successful");//регистрация пользователя успешна
        }

        private async Task<UserRating> FindRatingUserByName(string name) => 
            await appDbContext.Rating.FirstOrDefaultAsync(x => x.UserName == name);

        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserDTO deleteUserDTO)
        {
            var getUser = await FindUserByName(deleteUserDTO.Name!);
            if (getUser == null)
            {
                return new DeleteUserResponse(401, "User not found");
            }
            bool checkPassword = BCrypt.Net.BCrypt.Verify(deleteUserDTO.Password, getUser.Password);
            if (!checkPassword)
            {
                return new DeleteUserResponse(402, "Invalid credentails:incorrect password");
            }

            appDbContext.Users.Remove(getUser);
            appDbContext.Rating.Remove(await FindRatingUserByName(deleteUserDTO.Name));
            await appDbContext.SaveChangesAsync();

            return new DeleteUserResponse(200, "User has been successfully deleted");
        }
    }
}
