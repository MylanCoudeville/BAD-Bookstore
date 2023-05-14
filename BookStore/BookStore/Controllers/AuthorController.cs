using BookStore.Data;
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
            OverviewAuthorViewModel viewModel = new OverviewAuthorViewModel()
            {
                authors = _authorService.GetAllAuthors()
            };
            return View(viewModel);
        }
        public IActionResult AddAuthor()
        {
            return View();
        }
        public IActionResult EditAuthor(int Id)
        {
            EditAuthorViewModel viewModel = new EditAuthorViewModel()
            {
                EditAuthor = _authorService.GetById(Id)
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(author);
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAuthor(EditAuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                _authorService.UpdateAuthor(author.EditAuthor);
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }
        [HttpPost]
        public IActionResult Index(int Id) 
        {
            _authorService.RemoveAuthor(Id);
            return RedirectToAction("Index");
        }
    }
}
