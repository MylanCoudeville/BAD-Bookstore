using BookStore.Data;
using BookStore.Models.Author;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        /// <summary>
        /// Dependency Injection to access the database for CRUD operations with Authors
        /// </summary>
        private IAuthorService _authorService;
        /// <summary>
        /// Constructor of AuthorController
        /// </summary>
        /// <param name="authorService">IAuthorService-interface</param>
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        /// <summary>
        /// Function to go to the Index-page
        /// </summary>
        /// <returns></returns>
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
