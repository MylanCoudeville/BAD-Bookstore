using BookStore.Data;

namespace BookStore.Models.Order
{
    public class NewOrderViewModel
    {
        public Data.Order Order { get; set; }
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();
    }
}
