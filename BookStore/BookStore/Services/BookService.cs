using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private BookstoreDbContext _dbContext;
        public BookService(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _dbContext.Books.Select(Book => new Book()
                {
                    Id = Book.Id,
                    Title = Book.Title,
                    Isbn13 = Book.Isbn13,
                    Pages = Book.Pages,
                    Price = Book.Price,
                    Format = Book.Format,
                    AuthorID = Book.AuthorID,
                    Author = _dbContext.Authors.FirstOrDefault(x => x.Id == Book.AuthorID),
                    GenreId = Book.GenreId,
                    Genre = _dbContext.Genres.FirstOrDefault(x => x.Id == Book.GenreId),
                    UniqueUrl = Book.UniqueUrl
            }).ToList();
        }
        public Book GetById(int id)
        {
            return _dbContext.Books.Where(author => author.Id == id).Single();
        }
        public void AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }
}
