using BookStore.Data;
using BookStore.Models.Author;

namespace BookStore.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetById(int id);
        //EditAuthorViewModel GetAuthorToEdit(int id);
        void AddAuthor(Author author);
        void RemoveAuthor(int author);
        void UpdateAuthor(Author author);
    }
}
