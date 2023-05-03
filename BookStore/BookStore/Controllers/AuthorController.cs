using BookStore.Models.Author;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            IEnumerable<OverviewAuthorViewModel> authors = _authorService.GetAllAuthors();
            return View(authors);
        }
        public IActionResult AddAuthor()
        {
            return View();
        }
    }
}
