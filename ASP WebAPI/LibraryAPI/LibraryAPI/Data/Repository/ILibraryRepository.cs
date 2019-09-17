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
        Task<AuthorEntity> GetAuthorAsync(int id, bool showBooks = false);
        Task<IEnumerable<AuthorEntity>> GetAuthors(string orderBy = "id", bool showBooks = false);
        Task DeleteAuthorAsync(int id);
        void UpdateAuthor(AuthorEntity author);
        void CreateAuthor(AuthorEntity author);

        //books
        Book GetBook(int id);
        IEnumerable<Book> GetBooks();
        bool DeleteBook(int id);
        Book UpdateBook(Book book);
        Book CreateBook(Book book);

        //general
        Task<bool> SaveChangesAsync();
        void DetachEntity<T>(T entity) where T : class;
    }
}
