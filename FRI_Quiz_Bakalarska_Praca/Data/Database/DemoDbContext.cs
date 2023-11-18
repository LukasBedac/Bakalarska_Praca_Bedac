using Microsoft.EntityFrameworkCore;

namespace FRI_Quiz_Bakalarska_Praca.Data.Database
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) 
        {
             
        }
    }
}
