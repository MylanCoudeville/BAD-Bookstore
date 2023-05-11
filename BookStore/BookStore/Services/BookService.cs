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
        public IEnumerable<Book> GetBySearch(string search, int genreId, bool byTitle, bool byAuthor, bool byIsbn)
        {
            IEnumerable<Book> Books = new List<Book>();
            if (!string.IsNullOrEmpty(search))
            {
                if (byTitle)
                {
                    Books = _dbContext.Books.Where(book => book.Title.Contains(search));
                }
                if (byAuthor)
                {
                    Author a = _dbContext.Authors.Where(author => author.FirstName.Contains(search) || author.LastName.Contains(search)).Single();
                    Books = _dbContext.Books.Where(book => book.AuthorID == a.Id);
                }
                if (byIsbn)
                {
                    Books = _dbContext.Books.Where(book => book.Isbn13.Contains(search));
                }
                if (byTitle && byAuthor)
                {
                    Author a = _dbContext.Authors.Where(author => author.FirstName.Contains(search) || author.LastName.Contains(search)).Single();
                    Books = _dbContext.Books.Where(book => book.Title.Contains(search) || book.AuthorID == a.Id);
                }
                if (byTitle && byIsbn)
                {
                    Books = _dbContext.Books.Where(book => book.Title.Contains(search) || book.Isbn13.Contains(search));
                }
                if (byAuthor && byIsbn)
                {
                    Author a = _dbContext.Authors.Where(author => author.FirstName.Contains(search) || author.LastName.Contains(search)).Single();
                    Books = _dbContext.Books.Where(book => book.AuthorID == a.Id || book.Isbn13.Contains(search));
                }
                if (byTitle && byAuthor && byIsbn)
                {
                    Author a = _dbContext.Authors.Where(author => author.FirstName.Contains(search) || author.LastName.Contains(search)).Single();
                    Books = _dbContext.Books.Where(book => book.Title.Contains(search) || book.AuthorID == a.Id || book.Isbn13.Contains(search));
                }
                if (genreId != 0) Books = Books.Where(book => book.GenreId== genreId);
                return Books;
            }
            if (string.IsNullOrEmpty(search) && genreId != 0) 
            {
                Books = _dbContext.Books.Where(book => book.GenreId == genreId);
                return Books;
            }
            return GetAllBooks();
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
        public void EditBook(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }
}
