using BookStore.Data;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Book
{
    public class AddBookViewModel
    {
        public Data.Book AddBook { get; set; }
        public IEnumerable<Data.Author>? Authors { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
    }
}
