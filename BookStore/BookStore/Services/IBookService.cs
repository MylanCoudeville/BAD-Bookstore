using BookStore.Data;

namespace BookStore.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Get all the books that are stored in the database
        /// </summary>
        /// <returns>List of books</returns>
        IEnumerable<Book> GetAllBooks();
        /// <summary>
        /// Get a list of books which accepts the search requirements
        /// </summary>
        /// <param name="search">Word(s) on which will be searched</param>
        /// <param name="genreId">The unique ID of a genre</param>
        /// <param name="byTitle">Boolean: Is it searched on Title?</param>
        /// <param name="byAuthor">Boolean: Is it searched on the name of Author</param>
        /// <param name="byIsbn">Boolean: Is it searched on the unique ISBN-13</param>
        /// <returns></returns>
        IEnumerable<Book> GetBySearch(string search, int genreId, bool byTitle, bool byAuthor, bool byIsbn);
        /// <summary>
        /// Get the specific book by the unique ID
        /// </summary>
        /// <param name="id">Unique ID of the book</param>
        /// <returns>The specific book as an instations of the type Book</returns>
        Book GetById(int id);
        /// <summary>
        /// Add a book to the database
        /// </summary>
        /// <param name="book">Instation of the type book which has to be added to the database</param>
        void AddBook(Book book);
        /// <summary>
        /// Edit a specific book in the database
        /// </summary>
        /// <param name="book">Instation of the type book which has to be edited to the database</param>
        void EditBook(Book book);
    }
}
