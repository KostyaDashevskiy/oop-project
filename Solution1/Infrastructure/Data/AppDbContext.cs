using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //определение класса для работы с базой данных
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //добавление таблиц в базу данных
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserRating> Rating { get; set; }
        public DbSet<GameStatistics> Statistics { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<UserCountry> Country { get; set; }
        public DbSet<UserTwitch> Twitch { get; set; }
        public DbSet<UserInfo> Info { get; set; }

    }
}
