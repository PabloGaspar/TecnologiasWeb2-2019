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
        Task<Book> GetBookAsync(int authorId, int id);
        Task<Book> AddBookAsync(int authorId, Book book);
        Book EditBook(int authorId, int id, Book book);
        bool RemoveBook(int authorId, int id);
    }
}
