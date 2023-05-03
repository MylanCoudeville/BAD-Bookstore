using BookStore.Models.Author;

namespace BookStore.Services
{
    public interface IAuthorService
    {
        IEnumerable<OverviewAuthorViewModel> GetAllAuthors();
    }
}
