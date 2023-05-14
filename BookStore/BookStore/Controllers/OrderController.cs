using BookStore.Data;
using BookStore.Models.Order;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IBookService _bookService;
        private IAuthorService _authorService;
        private IOrderService _orderService;
        public OrderController(UserManager<ApplicationUser> userManager, IBookService bookService, IAuthorService authorService, IOrderService orderService)
        {
            _userManager = userManager;
            _bookService = bookService;
            _authorService = authorService;
            _orderService = orderService;
        }
        public IActionResult Successful()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            NewOrderViewModel viewModel = new NewOrderViewModel();
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ApplicationUser u = await _userManager.GetUserAsync(HttpContext.User);
                Order o = new Order()
                {
                    FirstName = u.Firstname,
                    LastName = u.Lastname,
                    UserId = u.Id
                };
                viewModel.Order = o;
            }
            viewModel.CartLines = HttpContext.Session.GetObjectFromJson<List<CartLine>>("Cart");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(NewOrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _orderService.AddOrder(viewModel.Order);
                Order lastOrder = _orderService.GetLastOrderInfo();
                if (lastOrder != null)
                {
                    foreach (CartLine item in HttpContext.Session.GetObjectFromJson<List<CartLine>>("Cart"))
                    {
                        double totalPrice = item.Quantity * item.BuyBook.Price;
                        _orderService.AddOrderLine(new OrderLine()
                        {
                            BookId = item.BuyBook.Id,
                            OrderId = lastOrder.Id,
                            Quantity = item.Quantity,
                            Price = totalPrice
                        });
                    }
                    return RedirectToAction("Successful");
                }
            }
            viewModel.CartLines = HttpContext.Session.GetObjectFromJson<List<CartLine>>("Cart");
            return View(viewModel);
        }
    }
}
