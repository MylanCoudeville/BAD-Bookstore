using BookStore.Data;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class IsUniqueISBN : ValidationAttribute
    {
        private BookstoreDbContext _context;
        
        public IsUniqueISBN() { }
        public override bool IsValid(object? value)
        {
            bool isNotUnique = _context.Books.Any(book => book.Isbn13 == value) ? false : true;
            return isNotUnique;
        }
    }
}
