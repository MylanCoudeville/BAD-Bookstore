using BookStore.Data;

namespace BookStore.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetById(int id);
    }
}
