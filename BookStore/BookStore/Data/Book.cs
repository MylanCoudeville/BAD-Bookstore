using BookStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "ISBN-13")]
        [Required]
        //[IsUniqueISBN]
        public string Isbn13 { get; set; }
        [Display(Name = "Number of pages")]
        [Required]
        public int Pages { get; set; }
        [Required]
        public Formats Format { get; set; }
        [Required]
        public double Price { get; set; }
        public int AuthorID { get; set; }
        [NotMapped]
        [ForeignKey("AuthorID")]
        public Author? Author { get; set; }
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        [NotMapped]
        public Genre? Genre { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? UniqueUrl { get; set; }
    }
    public enum Formats { Hardcover, Paperback, EBook }
}
