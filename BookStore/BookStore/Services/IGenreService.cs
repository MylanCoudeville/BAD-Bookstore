using BookStore.Data;

namespace BookStore.Services
{
    public interface IGenreService
    {
        /// <summary>
        /// Get all genres that are stored in the database
        /// </summary>
        /// <returns>List of instations of the type Genre</returns>
        IEnumerable<Genre> GetAllGenres();
        /// <summary>
        /// Get specific instation of the type Genre with the unique ID
        /// </summary>
        /// <param name="id">Unique ID of a genre</param>
        /// <returns>Instation of the type Genre</returns>
        Genre GetById(int id);
    }
}
