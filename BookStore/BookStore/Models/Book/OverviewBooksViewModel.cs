using BookStore.Data;
namespace BookStore.Models.Book
{
    public class OverviewBooksViewModel
    {
        public IEnumerable<Data.Book> AllBooks { get; set; }
        public IEnumerable<Genre> AllGenres { get; set; }
        public int GenreId { get; set; }
        public string? Search { get; set; }
        public Boolean ByTitle { get; set; }
        public Boolean ByAuthor { get; set; }
        public Boolean ByIsbn { get; set; }

    }
}
