using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Data.Entities;
using Library.Data.Repository;
using Library.Exceptions;
using Library.Models;

namespace Library.Services
{
    public class BooksService : IBooksService
    {
        private ILibraryRepository libraryRepository;
        private readonly IMapper mapper;
        public BooksService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            this.libraryRepository = libraryRepository;
            this.mapper = mapper;
        }

        public async Task<Book> AddBookAsync(int authorId, Book book)
        {
            if (book.AuthorId != null && authorId != book.AuthorId)
            {
                throw new BadRequestOperationException("URL author id and Book.AuthorId should be equal");
            }
            book.AuthorId = authorId;
            var authorEntity = await validatAuthorId(authorId);
            var bookEntity = mapper.Map<BookEntity>(book);

            libraryRepository.CreateBook(bookEntity);
            if (await libraryRepository.SaveChangesAsync())
            {
                return mapper.Map<Book>(bookEntity);
            }
            throw new Exception("There were an error with the DB");
        }

        public Book EditBook(int authorId, int id, Book book)
        {
            //ValidateAuthor(authorId);
            /*if (book.Id != null &&book.Id != id)
            {
                throw new InvalidOperationException("book URL id and book body id should be the same");
            }
            
            //ValidateAuthorAndBook(authorId, id);

            var bookToupdate = await libraryRepository.GetBookAsync(id);
            if (bookToupdate AuthorId != authorId)
            {
                throw new InvalidOperationException($"Author with id {authorId} doesn't have a book with id {id}");
            }*/

            book.AuthorId = authorId;
            return libraryRepository.UpdateBook(book);
        }

        public async Task<Book> GetBookAsync(int authorId, int id)
        {
            await ValidateAuthorAndBook(authorId, id);
            var bookEntity = await libraryRepository.GetBookAsync(id);
            return mapper.Map<Book>(bookEntity);
        }

        public IEnumerable<Book> GetBooks(int authorId)
        {
            
            //ValidateAuthorAndBook(authorId);
            return libraryRepository.GetBooks().Where(b => b.AuthorId == authorId);
        }

        public bool RemoveBook(int authorId, int id)
        {
            throw new NotImplementedException();
        }

        private async Task<AuthorEntity> validatAuthorId(int id, bool showBooks = false)
        {
            var author = await libraryRepository.GetAuthorAsync(id);
            if (author == null)
            {
                throw new NotFoundItemException($"cannot found author with id {id}");
            }

            return author;
        }

        private async Task<bool> ValidateAuthorAndBook(int authorId, int bookId)
        {

            var author = await libraryRepository.GetAuthorAsync(authorId);
            if (author == null)
            {
                throw new NotFoundItemException($"cannot found author with id {authorId}");
            }

            var book = await libraryRepository.GetBookAsync(bookId);
            if (book == null || book.Author.Id != authorId)
            {
                throw new NotFoundItemException($"Book not found with id {bookId} for author {authorId}");
            }

            return true;
        }
    }

  
}
