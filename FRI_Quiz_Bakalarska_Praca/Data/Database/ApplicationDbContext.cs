
using FRI_Quiz_Bakalarska_Praca.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;



namespace FRI_Quiz_Bakalarska_Praca.Data.Database
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

    }
        public DbSet<Kviz> Kvizy { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            connec
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        }*/

    }
}

