using BookStore.Data;
using BookStore.Models.Author;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private BookstoreDbContext _dbContext;
        public BookController(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Author> authors = _dbContext.Authors.Select(author => new Author()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthDate = author.BirthDate
            }).ToList();

            return View();
        }
        public IActionResult AddBook()
        {
            return View();
        }
    }
}
