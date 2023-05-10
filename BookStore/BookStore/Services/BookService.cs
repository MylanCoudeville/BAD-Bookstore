using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private BookstoreDbContext _dbContext;
        public IEnumerable<Book> GetAllBooks()
        {
            return _dbContext.Books.Select(Book => new Book()
            {
                Id = Book.Id,
                Title= Book.Title,
                Isbn13 = Book.Isbn13,
                Pages= Book.Pages,
                Price= Book.Price,
                Format= Book.Format,
                AuthorID= Book.AuthorID,
                GenreId = Book.GenreId
            }).ToList();
        }
        public void AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
        public void RemoveBook(int id)
        {

        }
    }
}
