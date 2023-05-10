using BookStore.Data;

namespace BookStore.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetById(int id);
        void AddBook(Book book);
    }
}
