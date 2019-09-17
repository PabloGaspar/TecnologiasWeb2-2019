using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IAuthorsService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync(string orderBy, bool showBooks);
        Task<Author> GetAuthorAsync(int id, bool showBooks);
        Task<Author> AddAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(int id, Author author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
