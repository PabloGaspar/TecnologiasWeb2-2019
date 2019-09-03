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
            validateAuthor(authorId);
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
            throw new NotImplementedException();
        }

        public Book GetBook(int authorId, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooks(int authorId)
        {
            //another comment
            //new coment
            validateAuthor(authorId);
            return libraryRepository.GetBooks().Where(b => b.AuthorId == authorId);
        }

        public bool RemoveBook(int authorId, int id)
        {
            throw new NotImplementedException();
        }

        private bool validateAuthor(int id)
        {
            var author = libraryRepository.GetAuthor(id);
            if (author == null)
            {
                throw new NotFoundItemException($"Author not found with id {id}");
            }

            return true;
        }
    }
}
