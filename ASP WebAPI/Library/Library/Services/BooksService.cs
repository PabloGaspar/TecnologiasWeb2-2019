using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Repository;
using Library.Exceptions;
using Library.Models;

namespace Library.Services
{
    public class BooksService : IBooksService
    {
        private ILibraryRepository libraryRepository;
        public BooksService(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        public Book AddBook(int authorId, Book book)
        {
            ValidateAuthor(authorId);
            if (book.AuthorId != null && authorId != book.AuthorId)
            {
                throw new BadRequestOperationException("URL author id and Book.AuthorId should be equal");
            }

            book.AuthorId = authorId;
            var bookCreated = libraryRepository.CreateBook(book);
            return bookCreated;
        }

        public Book EditBook(int authorId, int id, Book book)
        {
            ValidateAuthor(authorId);
            if (book.Id != null &&book.Id != id)
            {
                throw new InvalidOperationException("book URL id and book body id should be the same");
            }
            
            ValidateBook(id);

            var bookToupdate = libraryRepository.GetBook(id);
            if (bookToupdate.AuthorId != authorId)
            {
                throw new InvalidOperationException($"Author with id {authorId} doesn't have a book with id {id}");
            }

            book.AuthorId = authorId;
            return libraryRepository.UpdateBook(book);
        }

        public Book GetBook(int authorId, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooks(int authorId)
        {
            
            ValidateAuthor(authorId);
            return libraryRepository.GetBooks().Where(b => b.AuthorId == authorId);
        }

        public bool RemoveBook(int authorId, int id)
        {
            throw new NotImplementedException();
        }

        private bool ValidateAuthor(int id)
        {
            var author = libraryRepository.GetAuthor(id);
            if (author == null)
            {
                throw new NotFoundItemException($"Author not found with id {id}");
            }

            return true;
        }

        private bool ValidateBook(int id)
        {
            var book = libraryRepository.GetBook(id);
            if (book == null)
            {
                throw new NotFoundItemException($"Book not found with id {id}");
            }

            return true;
        }
    }

  
}
