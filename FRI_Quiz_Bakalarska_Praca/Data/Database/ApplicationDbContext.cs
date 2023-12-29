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
    
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        //protected readonly IConfiguration _config;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            //_config = configuration; -> do konstruktora ako param. IConfiguration configuration

        }
        public DbSet<Quiz> Kvizy { get; set; }
        public DbSet<Question> Otazky { get; set;}
        public DbSet<Answer> Odpovede { get; set; }
        public DbSet<User> Users {  get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(_config.GetConnectionString("DbConnectionString");
        }*/
    }
}

