using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<Author> authors;
        private List<Book> books;
        public LibraryRepository()
        {
            authors = new List<Author>()
            {
                new Author()
                {
                    id = 1,
                    LastName = "Tolkien",
                    Age = 87,
                    Name = "JRR",
                    Nationality = "south africa"
                },
                new Author()
                {
                    id = 2,
                    LastName = "King",
                    Age = 65,
                    Name = "Sthephen",
                    Nationality = "USA"
                }

            };

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
        public Author CreateAuthor(Author author)
        {
            var lastAuthor = authors.OrderByDescending(a => a.id).FirstOrDefault();
            var nextID = lastAuthor == null ? 1 : lastAuthor.id + 1;
            author.id = nextID;
            authors.Add(author);
            return author;
        }

        public Book CreateBook(Book book)
        {
            var latestBook = books.OrderByDescending(b => b.Id).FirstOrDefault();
            var nextBookId = latestBook == null ? 1 : latestBook.Id + 1;
            book.Id = nextBookId;
            books.Add(book);
            return book;
        }

        public bool DeleteAuhor(int id)
        {
            var authorToDelete = authors.Single(a => a.id == id);
            return authors.Remove(authorToDelete);
        }

        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(int id, bool showBooks)
        {
            var author = authors.SingleOrDefault(a => a.id == id);
            if (showBooks)
            {
                author.Books = books.Where(b => b.AuthorId == id);

            }
            return author;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authors;
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public Author UpdateAuthor(Author author)
        {
            var authorToUpdate = authors.Single(a => a.id == author.id);
            authorToUpdate.LastName = author.LastName;
            authorToUpdate.Name = author.Name;
            authorToUpdate.Age = author.Age;
            authorToUpdate.Nationality = author.Nationality;

            return authorToUpdate;


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
