using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IAuthorsService
    {
        IEnumerable<Author> GetAuthors(string orderBy);
        Author GetAuthor(int id);
        Author AddAuthor(Author author);
        Author UpdateAuthor(Author author);
        bool DeleteAuthor(int id);


    }
}
