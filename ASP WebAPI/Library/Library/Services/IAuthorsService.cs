using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IAuthorsService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync(bool showBooks, string orderBy);
        Task<Author> GetAuthorAsync(int id, bool showBooks);
        Task<Author> CreateAuthorAsync(Author newAuthor);
        Task<bool> DeleteAuthorAsync(int id);
        Task<Author> UpdateAuthorAsync(int id, Author newAuthor);
    }
}
