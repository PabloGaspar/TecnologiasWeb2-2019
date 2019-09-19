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
        Author UpdateAuthor(Author author);
        void CreateAuthor(AuthorEntity author);

        

        //books

        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        void CreateBook(BookEntity book);
        Book UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
