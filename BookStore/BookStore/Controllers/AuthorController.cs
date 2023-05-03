﻿using BookStore.Data;
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
        public IActionResult Index(int Id) 
        {
            _authorService.RemoveAuthor(Id);
            return RedirectToAction("Index");
        }
    }
}
