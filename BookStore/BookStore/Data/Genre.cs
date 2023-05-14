using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    [Table("Genres")]
    public class Genre
    {
        /// <summary>
        /// Unique value of a genre
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The name of a genre
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// A collection of books which has a specific genre
        /// </summary>
        public ICollection<Book> Books { get; set;}
    }
}
