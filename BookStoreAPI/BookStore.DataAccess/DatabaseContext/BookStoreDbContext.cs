using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.DatabaseContext
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
          : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthorLink> BookAuthorLinks { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<BookOrderLink> BookOrderLinks { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
    }
}
