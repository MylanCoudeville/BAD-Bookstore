namespace BookStore.Data
{
    public class ShoppingCart
    {
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();
    }
}
