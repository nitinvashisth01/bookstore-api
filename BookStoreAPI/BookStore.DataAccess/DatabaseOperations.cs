using BookStore.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess
{
    public class DatabaseOperations : IDatabaseOperations
    {
        private readonly BookStoreDbContext _context;
        public DatabaseOperations(BookStoreDbContext context)
        {
            _context = context;
        }

        public void ConfigureDatabase()
        {
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            _context.Database.EnsureCreated();
        }
    }
}
