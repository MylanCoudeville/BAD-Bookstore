namespace BookStore.Data
{
    public class ShoppingCart
    {
        /// <summary>
        /// A list of the class Cartlines
        /// </summary>
        public List<CartLine> CartLines { get; set; } = new List<CartLine>();
    }
}
