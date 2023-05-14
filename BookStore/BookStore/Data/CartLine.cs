namespace BookStore.Data
{
    public class CartLine
    {
        /// <summary>
        /// Class of the book the user wants to buy
        /// </summary>
        public Book BuyBook { get; set; }
        /// <summary>
        /// The amount of books the user wants to buy
        /// </summary>
        public int Quantity { get; set; }
    }
}
