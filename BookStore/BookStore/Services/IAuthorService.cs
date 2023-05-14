using BookStore.Data;
using BookStore.Models.Author;

namespace BookStore.Services
{
    public interface IAuthorService
    {
        /// <summary>
        /// Get all the Authors stored in the database
        /// </summary>
        /// <returns>List of authors</returns>
        IEnumerable<Author> GetAllAuthors();
        /// <summary>
        /// Get specific author by the unique ID of an Author
        /// </summary>
        /// <param name="id">The unique ID of an author</param>
        /// <returns>The specific author in an instations of the type Author</returns>
        Author GetById(int id);
        /// <summary>
        /// Add an author to the database
        /// </summary>
        /// <param name="author">The author who has to be added to the database</param>
        void AddAuthor(Author author);
        /// <summary>
        /// Remove an author from the database
        /// </summary>
        /// <param name="author">The author who has to be removed from the database</param>
        void RemoveAuthor(int author);
        /// <summary>
        /// Edit an author in the database
        /// </summary>
        /// <param name="author">The author who has to be edited in the database</param>
        void UpdateAuthor(Author author);
    }
}
