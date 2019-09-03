using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Data.Entities;
using LibraryAPI.Models;

namespace LibraryAPI.Data.Repository
{


    public class LibraryRepository : ILibraryRepository
    {
        private List<Author> authors = new List<Author>();
        private List<Book> books = new List<Book>();
        private LibraryDBContext libraryDBContext;
        public LibraryRepository(LibraryDBContext libraryDBContext)
        {
            this.libraryDBContext = libraryDBContext;
            authors.Add(new Author()
            {
                Id = 1,
                Age = 44,
                LastName = "Saint-Exupery",
                Name = "Antoine",
                Nationallity = "France"
            });

            authors.Add(new Author()
            {
                Id = 2,
                Age = 85,
                LastName = "Tolkien",
                Name = "JRR",
                Nationallity = "South Africa",
            });

            authors.Add(new Author()
            {
                Id = 3,
                Age = 75,
                LastName = "Lovecraft",
                Name = "HP",
                Nationallity = "USA",
            });

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

        public bool DeleteAuthor(int id)
        {
            var author = authors.Single(a => a.Id == id);
            authors.Remove(author);
            return true;
        }

        public bool DeleteBook(int id)
        {
            var book = books.Single(b => b.Id == id);
            books.Remove(book);
            return true;
        }

        public Author GetAuthor(int id)
        {
            return authors.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authors;
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

        public Author UpdateAuthor(Author author)
        {
            var authorToUpdate = authors.Single(a => a.Id == author.Id);
            authorToUpdate.LastName = author.LastName;
            authorToUpdate.Name = author.Name;
            authorToUpdate.Nationallity = author.Nationallity;
            authorToUpdate.Age = author.Age;
            return author;
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
