using Library.Data.Entities;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public interface ILibraryRepository
    {
        Task<bool> SaveChangesAsync();

        //authors
        Task <AuthorEntity> GetAuthorAsync(int id, bool showBooks = false);
        Task<IEnumerable<AuthorEntity>> GetAuthorsAsync(bool showBooks = false, string orderBy = "id");
        Task DeleteAuthorAsync(int id);
        void UpdateAuthor(AuthorEntity author);
        void CreateAuthor(AuthorEntity author);

        

        //books

        IEnumerable<Book> GetBooks();
        Task<BookEntity> GetBookAsync(int id, bool showAuthor = false);
        void CreateBook(BookEntity book);
        void UpdateBook(BookEntity book);
        bool DeleteBook(int id);
    }
}
