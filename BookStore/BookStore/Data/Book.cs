namespace BookStore.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn13 { get; set; }
        public int Pages { get; set; }
        public Formats Format { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
    public enum Formats { Hardcover, Paperback, EBook }
}
