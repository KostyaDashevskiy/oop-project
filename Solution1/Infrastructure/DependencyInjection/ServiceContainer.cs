using Application.Contract;
using Infrastructure.Data;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyInjection
{
    //подключение базы данных к программе
    public static class ServiceContainer
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services,
            IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
                ServiceLifetime.Scoped);

            /*services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("Default")));*/

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
            services.AddScoped<IRating, RatingRepo>();
            services.AddScoped<IUser, UserRepo>();
            services.AddScoped<IGames, StatisticsRepo>();
            services.AddScoped<IProfile, ProfileRepo>();
            services.AddScoped<ICountry, CountryRepo>();
            services.AddScoped<ITwitch, TwitchRepo>();
            services.AddScoped<IInfo, InfoRepo>();

            return services;
        }
    }
}
