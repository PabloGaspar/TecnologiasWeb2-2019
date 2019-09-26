using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<Book> books;
        private LibraryDbContext libraryDbContext;
        public LibraryRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;

            books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    AuthorId = 1,
                    Genre = "Fantasy",
                    Pages = 400,
                    Tittle = "The Silmarillon"

                },
                new Book()
                {
                    Id = 2,
                    AuthorId = 1,
                    Genre = "Fantasy",
                    Pages = 300,
                    Tittle = "The Lord of the Rings"

                },
                new Book()
                {
                    Id = 3,
                    AuthorId = 2,
                    Genre = "Horror",
                    Pages = 300,
                    Tittle = "It"
                },
                new Book()
                {
                    Id = 4,
                    AuthorId = 2,
                    Genre = "Horror",
                    Pages = 300,
                    Tittle = "The Shining"
                }
            };

        }
        public void CreateAuthor(AuthorEntity author)
        {
            libraryDbContext.Authors.Add(author);
        }

        public void CreateBook(BookEntity book)
        {
            /**var latestBook = books.OrderByDescending(b => b.Id).FirstOrDefault();
            var nextBookId = latestBook == null ? 1 : latestBook.Id + 1;
            book.Id = nextBookId;
            books.Add(book);
            return book;*/
            libraryDbContext.Books.Add(book);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var authorToDelete = await libraryDbContext.Authors.SingleAsync(a=>a.Id==id);
            libraryDbContext.Authors.Remove(authorToDelete);
        }

        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorEntity> GetAuthorAsync(int id, bool showBooks)
        {
            //var author = authors.SingleOrDefault(a => a.id == id);
            //if (showBooks)
            //{
            //    author.Books = books.Where(b => b.AuthorId == id);

            //}
            //return author;
            IQueryable<AuthorEntity> query = libraryDbContext.Authors;

            if (showBooks)
            {
                query = query.Include(a => a.Books);
            }

            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AuthorEntity>> GetAuthorsAsync(bool showBooks, string orderBy)
        {
            IQueryable<AuthorEntity> query = libraryDbContext.Authors;
            if (showBooks)
            {
                query = query.Include(a => a.Books);
            }
            
            switch (orderBy)
            {
                case "name":
                    query = query.OrderBy(a => a.Name);
                    break;
                case "lastname":
                    query = query.OrderBy(a => a.LastName);
                    break;
                case "age":
                    query = query.OrderBy(a => a.Age);
                    break;
                default:
                    query = query.OrderBy(a => a.Id);
                    break;
            }
            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await libraryDbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateAuthor(AuthorEntity author)
        {
            /*var authorToUpdate = libraryDBContext.Authors.Single(a => a.Id == author.Id);
            authorToUpdate.LastName = author.LastName;
            authorToUpdate.Name = author.Name;
            authorToUpdate.Nationallity = author.Nationallity;
            authorToUpdate.Age = author.Age;*/

            libraryDbContext.Authors.Update(author);
        }

        public Book UpdateBook(Book book)
        {
            var bookToUpdate = books.Single(b => b.Id == book.Id);
            bookToUpdate.Pages = book.Pages;
            bookToUpdate.Tittle = book.Tittle;
            bookToUpdate.Genre = book.Genre;
            return bookToUpdate;
        }
    }
}
