using BookStore.Data;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Book
{
    public class AddBookViewModel
    {
        [Required]
        public string Title { get; set; }
        [Display(Name ="ISBN-13")]
        [Required]
        [IsUniqueISBN()]
        public string ISBN13 { get; set; }
        [Display(Name ="Number of pages")]
        [Required]
        public int Pages { get; set; }
        [Required]
        public Formats Format { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Data.Author Author { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public IFormFile CoverImage { get; set; }
    }
}
