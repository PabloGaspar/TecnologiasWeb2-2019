using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public interface ILibraryRepository
    {

        //authors
        Author GetAuthor(int id);
        IEnumerable<Author> GetAuthors();
        bool DeleteAuhor(int id);
        Author UpdateAuthor(Author author);
        Author CreateAuthor(Author author);

        //books

    }
}
