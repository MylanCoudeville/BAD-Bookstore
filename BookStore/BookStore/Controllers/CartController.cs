using Microsoft.AspNetCore.Mvc;
using BookStore.Data;
using BookStore.Services;
//using Newtonsoft.Json;
using System.Text.Json;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCart Cart;
        private IBookService _bookService;
        private IAuthorService _authorService;
        public CartController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }
        public IActionResult Index()
        {
            ShoppingCart Cart = new ShoppingCart();
            Cart.CartLines = HttpContext.Session.GetObjectFromJson<List<CartLine>>("Cart");
            return View(Cart);
        }

        public IActionResult AddToCart()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddToCart(int bookId, int Quantity)
        {
            Cart = new ShoppingCart();
            Cart.CartLines = new List<CartLine>();
            if (SessionHelper.GetObjectFromJson<List<CartLine>>(HttpContext.Session, "Cart") == null)
            {
                Book b = _bookService.GetById(bookId);
                b.Author = _authorService.GetById(b.AuthorID);
                b.Author.Books = null;
                Cart.CartLines.Add(new CartLine() { BuyBook = b, Quantity = Quantity });
            }
            if (SessionHelper.GetObjectFromJson<List<CartLine>>(HttpContext.Session, "Cart") != null)
            {
                Cart.CartLines = SessionHelper.GetObjectFromJson<List<CartLine>>(HttpContext.Session, "Cart");
                if (Cart.CartLines.Any(Cartline => Cartline.BuyBook.Id == bookId)) Cart.CartLines.Find(book => book.BuyBook.Id == bookId).Quantity += Quantity;
                else
                {
                    Book b = _bookService.GetById(bookId);
                    b.Author = _authorService.GetById(b.AuthorID);
                    b.Author.Books = null;
                    Cart.CartLines.Add(new CartLine() { BuyBook = b, Quantity = Quantity });
                }
            }
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(Cart.CartLines));
            return RedirectToAction("Index");
        }
    }
}
