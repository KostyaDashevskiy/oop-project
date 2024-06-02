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

        /*private async Task<UserRating> FindUserByID(int Id) =>
            await appDbContext.Rating.FirstOrDefaultAsync(x => x.Id == Id);*/

        public RatingRepo(AppDbContext appDbContext, IConfiguration configuration)
        {
            this.appDbContext = appDbContext;
            this.configuration = configuration;
        }

        public async Task<RatingResponse> IncreaseMMR(RatingDTO ratingDTO)
        {
            return new RatingResponse(true, 1);
            /*var userRating = await FindUserByID(ratingDTO.UserId);
            if (userRating == null)
            {
                return new RatingResponse(false, 0);
            }
        
            userRating.Rating += 25;
            appDbContext.Rating.Update(userRating);
            await appDbContext.SaveChangesAsync();
        
            return new RatingResponse(true, userRating.Rating);*/
        }
        
        public async Task<RatingResponse> DecreaseMMR(RatingDTO ratingDTO)
        {
            return new RatingResponse(true, 1);
            /*var userRating = await FindUserByID(ratingDTO.UserId);
            if (userRating == null)
            {
                return new RatingResponse(false, 0);
            }
            
            userRating.Rating -= 25;
            appDbContext.Rating.Update(userRating);
            await appDbContext.SaveChangesAsync();
            
            return new RatingResponse(true, userRating.Rating);*/
        }
        
        public async Task<RatingResponse> getUserMMR(RatingDTO ratingDTO)
        {
            return new RatingResponse(true, 1);
            /*var userRating = await FindUserByID(ratingDTO.UserId);
            if (userRating == null)
            {
                return new RatingResponse(false, 0);
            }
            
            return new RatingResponse(true, userRating.Rating);*/
        }
    }
}
