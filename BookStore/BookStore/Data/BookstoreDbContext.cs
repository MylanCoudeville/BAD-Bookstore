using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
    }
}
