﻿using BookStore.Data;
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
    }
}
