using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult AddBook()
        {
            return View();
        }
    }
}
