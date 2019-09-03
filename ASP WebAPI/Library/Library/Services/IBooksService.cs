using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IBooksService
    {
        IEnumerable<Book> GetBooks(int authorId);
        Book GetBook(int authorId, int id);
        Book AddBook(int authorId, Book book);
        Book EditBook(int authorId, int id, Book book);
        bool RemoveBook(int authorId, int id);
    }
}
