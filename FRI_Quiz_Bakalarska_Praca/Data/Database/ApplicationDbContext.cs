using FRI_Quiz_Bakalarska_Praca.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Configuration;
namespace FRI_Quiz_Bakalarska_Praca.Data.Database
{
    
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        //protected readonly IConfiguration _config;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //_config = configuration; -> do konstruktora ako param. IConfiguration configuration

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 1, Name = "admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 2, Name = "moderator", NormalizedName = "MODERATOR" });
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        
    }
}

