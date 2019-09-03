using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IAuthorsService
    {
        IEnumerable<Author> GetAuthors(string orderBy, bool showBooks);
        Author GetAuthor(int id, bool showBooks);
        Task<Author> AddAuthorAsync(Author author);
        Author UpdateAuthor(int id, Author author);
        bool DeleteAuthor(int id);
    }
}
