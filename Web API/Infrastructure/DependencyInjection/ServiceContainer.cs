using Application.Contract.ApplicationUser;
using Application.Contract.GameProfile;
using Application.Contract.Guild;
using Application.Contract.PersonalProfile;
using Infrastructure.Data;
using Infrastructure.Repo.AppUser;
using Infrastructure.Repo.GameProfile;
using Infrastructure.Repo.Guild;
using Infrastructure.Repo.PersonalProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.DependencyInjection
{
    //подключение базы данных к программе
    public static class ServiceContainer
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services,
            IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default"),//Default - строка подключения к бд
                b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
                ServiceLifetime.Scoped);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });
            
            //добавление зависимостей
            services.AddScoped<IRating, RatingRepo>();
            services.AddScoped<IUser, UserRepo>();
            services.AddScoped<IGames, StatisticsRepo>();
            services.AddScoped<IProfile, ProfileRepo>();
            services.AddScoped<ICountry, CountryRepo>();
            services.AddScoped<ITwitch, TwitchRepo>();
            services.AddScoped<IAge, AgeRepo>();
            services.AddScoped<IAbout, AboutRepo>();
            services.AddScoped<IInfo, InfoRepo>();
            services.AddScoped<IGuild, GuildRepo>();

            return services;
        }
    }
}
