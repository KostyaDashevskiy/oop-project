using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
