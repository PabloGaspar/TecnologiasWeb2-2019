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
        Author GetAuthor(int id, bool showBooks = false);
        IEnumerable<Author> GetAuthors();
        bool DeleteAuhor(int id);
        Author UpdateAuthor(Author author);
        Author CreateAuthor(Author author);

        //books

        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book CreateBook(Book book);
        Book UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
