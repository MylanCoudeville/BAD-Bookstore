using BookStore.Data;

namespace BookStore.Services
{
    public class GenreService : IGenreService
    {
        private BookstoreDbContext _dbContext;
        public GenreService(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _dbContext.Genres.Select(genre => new Genre()
            {
                Id = genre.Id,
                Name = genre.Name
            }).ToList();
        }
    }
}
