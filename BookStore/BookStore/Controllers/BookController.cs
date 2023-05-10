using BookStore.Data;
using BookStore.Models.Author;
using BookStore.Models.Book;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookService _BookService;
        private IAuthorService _AuthorService;
        private IGenreService _GenreService;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public BookController(IBookService bookService, IAuthorService authorService, IGenreService genreService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _BookService = bookService;
            _AuthorService = authorService;
            _GenreService = genreService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            OverviewBooksViewModel viewModel = new OverviewBooksViewModel()
            {
                AllBooks = _BookService.GetAllBooks()
            };
            return View(viewModel);
        }
        public IActionResult AddBook()
        {
            AddBookViewModel viewModel = new AddBookViewModel()
            {
                Authors = _AuthorService.GetAllAuthors(),
                Genres = _GenreService.GetAllGenres()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(AddBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = GetUniqueFileName(book.AddBook.Image.FileName);
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img");
                string filePath = Path.Combine(uploads, uniqueFileName);
                book.AddBook.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                Book newBook = new Book()
                {
                    Title = book.AddBook.Title,
                    Isbn13 = book.AddBook.Isbn13,
                    Pages = book.AddBook.Pages,
                    Price = book.AddBook.Price,
                    Format = book.AddBook.Format,
                    AuthorID = book.AddBook.AuthorID,
                    GenreId = book.AddBook.GenreId,
                    UniqueUrl = uniqueFileName
                };
                _BookService.AddBook(newBook);

                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        //https://stackoverflow.com/questions/35379309/how-to-upload-files-in-asp-net-core/35385472#35385472
    }
}
