using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Data.Repository;
using LibraryAPI.Exceptions;
using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public class BooksService : IBooksService
    {

        private ILibraryRepository authorsRepository;

        public BooksService(ILibraryRepository authorsRepository)
        {
            this.authorsRepository = authorsRepository;
        }

        public Book AddBook(int authorId, Book book)
        {
            ValidateAuthor(authorId);
            book.AuthorId = authorId;
            var bookCreated = authorsRepository.CreateBook(book);
            return bookCreated;
        }

        public bool DeleteBook(int authorId, int id)
        {
            ValidateAuthor(authorId);
            var bookToDelete = authorsRepository.GetBooks().SingleOrDefault(b => b.Id == id);
            if (bookToDelete == null)
            {
                throw new NotFoundException("invalid book to delete");
            }
            return authorsRepository.DeleteBook(id);
        }

        public Book GetBook(int authorId, int id)
        {
            ValidateAuthor(authorId);
            var book = authorsRepository.GetBook(id);
            if (book == null)
            {
                throw new NotFoundException("invalid book");
            }
            if (book.AuthorId != authorId)
            {
                throw new NotFoundException("book does not exist");
            }

            return book;
        }

        public IEnumerable<Book> GetBooks(int authorId)
        {
            ValidateAuthor(authorId);
            return authorsRepository.GetBooks().Where(b => b.AuthorId == authorId);
        }

        public Book UpdateBook(int authorId, int id, Book book)
        {
            ValidateAuthor(authorId);
            var bookToUpdate = authorsRepository.GetBook(id);
            if (bookToUpdate == null)
            {
                throw new NotFoundException("invalid book");
            }

            book.Id = id;

            return authorsRepository.UpdateBook(bookToUpdate);          
        }

        private void ValidateAuthor(int authorId)
        {
            var author = authorsRepository.GetAuthor(authorId);
            if (author == null)
            {
                throw new NotFoundException($"author with id {authorId} not found");
            }
        }
    }
}
