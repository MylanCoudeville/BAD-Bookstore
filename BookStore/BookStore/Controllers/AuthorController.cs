using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddAuthor()
        {
            return View();
        }
    }
}
