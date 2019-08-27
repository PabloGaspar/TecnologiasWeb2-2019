using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks(int authorId);
        Book GetBook(int authorId, int id);
        Book AddBook(int authorId, Book book);
        Book UpdateBook(int authorId, int id, Book book);
        bool DeleteBook(int authorId, int id);
    }
}
