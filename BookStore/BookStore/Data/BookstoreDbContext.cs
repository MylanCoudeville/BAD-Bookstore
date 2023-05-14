using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookstoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>()
                .HasMany(author => author.Books).WithOne()
                .HasForeignKey(book => book.AuthorID)
                .OnDelete(DeleteBehavior.Restrict); //moet nog restrict worden
            //modelBuilder.Entity<Book>().HasIndex(book => book.Isbn13).IsUnique();
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { Id = 1, Name = "Biografie" },
                new Genre() { Id = 2, Name = "Sciencefiction" },
                new Genre() { Id = 3, Name = "Romantiek en chicklit" },
                new Genre() { Id = 4, Name = "Thriller, detective, spanning" },
                new Genre() { Id = 5, Name = "Historische fictie" },
                new Genre() { Id = 6, Name = "Grappige fictie" },
                new Genre() { Id = 7, Name = "Kortverhalen en novelles" },
                new Genre() { Id = 8, Name = "Geld en economie" },
                new Genre() { Id = 9, Name = "Gezondheid en ziekte" },
                new Genre() { Id = 10, Name = "Sprookjes en verhaaltjesboeken" }
                );
        }
    }
}
