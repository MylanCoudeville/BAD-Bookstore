﻿namespace BookStore.Models.Author
{
    public class OverviewAuthorViewModel : Data.Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}