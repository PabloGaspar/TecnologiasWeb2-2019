using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IAuthorsService
    {
        IEnumerable<Author> GetAuthors(string orderBy);
        Author GetAuthor(int id, bool showBooks);
        Author CreateAuthor(Author newAuthor);
        bool DeleteAuthor(int id);
        Author UpdateAuthor(int id, Author newAuthor);
    }
}
