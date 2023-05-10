using BookStore.Data;

namespace BookStore.Models.Book
{
    public class EditBookViewModel
    {
        public Data.Book ToEditBook { get; set; }
        public IEnumerable<Data.Author>? Authors { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
    }
}
