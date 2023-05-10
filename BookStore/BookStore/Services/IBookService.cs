using BookStore.Data;

namespace BookStore.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book book);
    }
}
