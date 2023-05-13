using Microsoft.AspNetCore.Mvc;
using BookStore.Data;
using BookStore.Services;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCart Cart = new ShoppingCart();
        private IBookService _bookService;
        private IAuthorService _authorService;
        public CartController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }
        public IActionResult Index()
        {
            ShoppingCart cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            return View(cart);
        }
        [HttpPost]
        public IActionResult AddToShoppingCart(int bookId, int amount)
        {
            Book b = _bookService.GetById(bookId);
            b.Author = _authorService.GetById(b.AuthorID);
            Cart.CartLines.Add(new CartLine() { BuyBook = b, Quantity = amount });
            HttpContext.Session.Remove("Cart");
            if (Cart != null) HttpContext.Session.SetObjectAsJson("Cart", Cart);
            return RedirectToAction("Index");
        }
    }
}
