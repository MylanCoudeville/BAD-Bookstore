using BookStore.Data;

namespace BookStore.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBySearch(string search, int genreId, bool byTitle, bool byAuthor, bool byIsbn);
        Book GetById(int id);
        void AddBook(Book book);
        void EditBook(Book book);
    }
}
