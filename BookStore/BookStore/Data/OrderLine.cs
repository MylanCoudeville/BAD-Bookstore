using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [NotMapped]
        public Order Order { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [NotMapped]
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
