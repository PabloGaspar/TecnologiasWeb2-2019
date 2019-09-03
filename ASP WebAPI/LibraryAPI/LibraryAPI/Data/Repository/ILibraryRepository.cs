using LibraryAPI.Data.Entities;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Data.Repository
{
    public interface ILibraryRepository
    {
        //authors
        Author GetAuthor(int id);
        IEnumerable<Author> GetAuthors();
        bool DeleteAuthor(int id);
        Author UpdateAuthor(Author author);
        void CreateAuthor(AuthorEntity author);

        //books
        Book GetBook(int id);
        IEnumerable<Book> GetBooks();
        bool DeleteBook(int id);
        Book UpdateBook(Book book);
        Book CreateBook(Book book);

        //general
        Task<bool> SaveChangesAsync();
    }
}
