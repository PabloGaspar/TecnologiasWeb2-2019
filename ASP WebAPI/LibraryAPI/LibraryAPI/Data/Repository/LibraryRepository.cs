using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Data.Entities;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data.Repository
{


    public class LibraryRepository : ILibraryRepository
    {
        private List<Book> books = new List<Book>();
        private LibraryDBContext libraryDBContext;
        public LibraryRepository(LibraryDBContext libraryDBContext)
        {
            this.libraryDBContext = libraryDBContext;

            books.Add(new Book()
            {
                AuthorId = 1,
                Genre = "Novel",
                Pages = 80,
                Title = "The little prince",
                Id = 1
            });

            books.Add(new Book()
            {
                AuthorId = 2,
                Genre = "Fantasy",
                Pages = 364,
                Title = "The Silmarillon",
                Id = 2
            });

            books.Add(new Book()
            {
                AuthorId = 2,
                Genre = "Fantasy",
                Pages = 400,
                Title = "The lord of the rings",
                Id = 3
            });

            books.Add(new Book()
            {
                AuthorId = 3,
                Genre = "Horror",
                Pages = 464,
                Title = "The call of Cthulu",
                Id = 4
            });

            books.Add(new Book()
            {
                AuthorId = 3,
                Genre = "Horror",
                Pages = 500,
                Title = "Dagon",
                Id = 5
            });
        }


        public void CreateAuthor(AuthorEntity author)
        {
            /*var nextId = authors.OrderByDescending(a => a.Id).FirstOrDefault().Id + 1;
            author.Id = nextId;
            this.authors.Add(author);
            return author;*/
            var savedAuthor = libraryDBContext.Authors.Add(author);
        }

        public Book CreateBook(Book book)
        {
            var lastAuthorBook = books.Where(b => b.AuthorId == book.AuthorId).OrderBy(b => b.Id).FirstOrDefault();
            int nextId = lastAuthorBook == null ? 1 : lastAuthorBook.Id + 1;
            book.Id = nextId;
            books.Add(book);
            return book;
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await libraryDBContext.Authors.SingleAsync(a => a.Id == id);
            libraryDBContext.Authors.Remove(author);
        }

        public bool DeleteBook(int id)
        {
            var book = books.Single(b => b.Id == id);
            books.Remove(book);
            return true;
        }

        public void DetachEntity<T>(T entity) where T : class
        {
            libraryDBContext.Entry(entity).State = EntityState.Detached;
        }

        public async Task<AuthorEntity> GetAuthorAsync(int id, bool showBooks)
        {
            IQueryable<AuthorEntity> query = libraryDBContext.Authors;

            if (showBooks)
            {
                query = query.Include(a => a.Books);
            }

            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AuthorEntity>> GetAuthors(string orderBy, bool showBooks)
        {
            IQueryable<AuthorEntity> query = libraryDBContext.Authors;

            if (showBooks)
            {
                query = query.Include(a => a.Books);
            }

            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(a => a.Id);
                    break;
                case "name":
                    query = query.OrderBy(a => a.Name);
                    break;
                case "lastname":
                    query = query.OrderBy(a => a.LastName);
                    break;
                case "nationallity":
                    query = query.OrderBy(a => a.Name);
                    break;
                default:
                    break;
            }

           return await query.ToArrayAsync();
        }

        public Book GetBook(int id)
        {
            return books.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await libraryDBContext.SaveChangesAsync()) > 0;
        }

        public void UpdateAuthor(AuthorEntity author)
        {
            /*var authorToUpdate = libraryDBContext.Authors.Single(a => a.Id == author.Id);
            authorToUpdate.LastName = author.LastName;
            authorToUpdate.Name = author.Name;
            authorToUpdate.Nationallity = author.Nationallity;
            authorToUpdate.Age = author.Age;*/

            libraryDBContext.Authors.Update(author);
        }

        public Book UpdateBook(Book book)
        {
            var bookToUpdate = books.Single(b => b.Id == book.Id);
            bookToUpdate.Genre = book.Genre;
            bookToUpdate.Pages = book.Pages;
            bookToUpdate.Title = book.Title;
            return book;
        }
    }
}
