using Microsoft.EntityFrameworkCore;

namespace FRI_Quiz_Bakalarska_Praca.Data.Database
{
    public class DbController
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public DbController(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
