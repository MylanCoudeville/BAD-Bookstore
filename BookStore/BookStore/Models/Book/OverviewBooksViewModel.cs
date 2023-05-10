using BookStore.Data;
namespace BookStore.Models.Book
{
    public class OverviewBooksViewModel
    {
        public IEnumerable<Data.Book> AllBooks { get; set; }
    }
}
