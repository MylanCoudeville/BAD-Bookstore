using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    public class OrderLine
    {
        /// <summary>
        /// Unique ID of the orderline
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Unique ID of the order
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// The class of the order to access information
        /// </summary>
        [ForeignKey("OrderId")]
        [NotMapped]
        public Order Order { get; set; }
        /// <summary>
        /// The unique Id of the book
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// The class of the Book to acces information
        /// </summary>
        [ForeignKey("BookId")]
        [NotMapped]
        public Book Book { get; set; }
        /// <summary>
        /// The amount of books the user wants to buy a specific book
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Price of the book at the moment the book was bought
        /// </summary>
        public double Price { get; set; }
    }
}
