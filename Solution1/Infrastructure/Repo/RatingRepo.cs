using System;
using Application.Contract;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo
{
    internal class RatingRepo : IRating
    {
        private readonly AppDbContext appDbContext;
        private readonly IConfiguration configuration;

        public RatingRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        private async Task<UserRating> FindUserByName(string name) =>
    await appDbContext.Rating.FirstOrDefaultAsync(x => x.UserName == name);

        public async Task<RatingResponse> ManipulateMMR(RatingDTO ratingDTO, RatigStatus status)
        {

            var getUser = await FindUserByName(ratingDTO.UserName);
            if (getUser == null)
            {
                return new RatingResponse(401, "No user with this username was found"); //пользователь не найден
            }

            switch (status)
            {
                case RatigStatus.Victory:
                    getUser.Rating += 25;
                    break;
                case RatigStatus.Defeat:
                    getUser.Rating -= 25;
                    break;
                case RatigStatus.Draw:
                    break;
                default:
                    break;
            }

            appDbContext.SaveChanges();

            return new RatingResponse(200, getUser.Rating.ToString());
        }
    }
}
