using BookStore.Data;
using BookStore.Models.Author;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookStore.Services
{
    public class AuthorService : IAuthorService
    { 
        private BookstoreDbContext _dbContext;
        public AuthorService(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OverviewAuthorViewModel> GetAllAuthors()
        {
            return _dbContext.Authors.Select(author => new OverviewAuthorViewModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthDate = author.BirthDate
            }).ToList();
        }
        public Author GetById(int id)
        {
            return _dbContext.Authors.Where(author => author.Id == id).Single();
        }
        public EditAuthorViewModel GetAuthorToEdit(int Id)
        {
            return _dbContext.Authors.Select(author => new EditAuthorViewModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BirthDate = author.BirthDate
            }).Where(author => author.Id == Id).Single();
        }
        public void AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }
        public void RemoveAuthor(int authorId)
        {
            _dbContext.Authors.Remove(GetById(authorId));
            _dbContext.SaveChanges();
        }
        public void UpdateAuthor(Author author)
        {
            _dbContext.Authors.Update(author);
            _dbContext.SaveChanges();
        }
    }
}
