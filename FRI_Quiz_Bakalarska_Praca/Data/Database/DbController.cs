namespace FRI_Quiz_Bakalarska_Praca.Data.Database
{
    public class DbController
    {
        private readonly ApplicationDbContext _context;

        public DbController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
