using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Data.Repository
{
    public interface IAuthorsRepository
    {
        //authors
        Author GetAuthor(int id);
        IEnumerable<Author> GetAuthors();
        bool DeleteAuthor(int id);
        Author UpdateAuthor(Author author);
        Author CreateAuthor(Author author);

        //books
        Book GetBook(int id);
        IEnumerable<Book> GetBooks();
        bool DeleteBook(int id);
        Book UpdateBook(Book book);
        Book CreateBook(Book book);
    }
}
