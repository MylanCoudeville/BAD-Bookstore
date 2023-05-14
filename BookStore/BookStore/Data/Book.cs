using BookStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    [Table("Books")]
    public class Book
    {
        /// <summary>
        /// Unique value of a book
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Title of the book
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Unique ISBN-13 code
        /// </summary>
        [Display(Name = "ISBN-13")]
        [Required]
        //[IsUniqueISBN]
        public string Isbn13 { get; set; }
        /// <summary>
        /// Amount of pages
        /// </summary>
        [Display(Name = "Number of pages")]
        [Required]
        public int Pages { get; set; }
        /// <summary>
        /// Format of the book (Ebook, Hardcover, Paperback)
        /// </summary>
        [Required]
        public Formats Format { get; set; }
        /// <summary>
        /// Price of the book
        /// </summary>
        [Required]
        public double Price { get; set; }
        /// <summary>
        /// Unique ID of the author who wrote the book
        /// </summary>
        public int AuthorID { get; set; }
        /// <summary>
        /// The class to get the information of the author who wrote the book
        /// </summary>
        [NotMapped]
        [ForeignKey("AuthorID")]
        public Author? Author { get; set; }
        /// <summary>
        /// The unique ID of the genre
        /// </summary>
        [Required]
        public int GenreId { get; set; }
        /// <summary>
        /// The class to get the information of the genre
        /// </summary>
        [ForeignKey("GenreId")]
        [NotMapped]
        public Genre? Genre { get; set; }
        /// <summary>
        /// Datatype to store an path to an Image
        /// </summary>
        [NotMapped]
        public IFormFile? Image { get; set; }
        /// <summary>
        /// URL for the image of the cover
        /// </summary>
        public string? UniqueUrl { get; set; }
    }
    /// <summary>
    /// Enum of which format of book it could be
    /// </summary>
    public enum Formats { Hardcover, Paperback, EBook }
}
