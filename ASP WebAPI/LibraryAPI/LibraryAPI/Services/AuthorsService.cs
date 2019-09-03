using AutoMapper;
using LibraryAPI.Data.Entities;
using LibraryAPI.Data.Repository;
using LibraryAPI.Exceptions;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvalidOperationException = LibraryAPI.Exceptions.InvalidOperationException;

namespace LibraryAPI.Services
{
    public class AuthorsService : IAuthorsService
    {
        private ILibraryRepository authorsRepository;
        private readonly IMapper mapper;

        public AuthorsService(ILibraryRepository authorsRepository, IMapper mapper)
        {
            this.authorsRepository = authorsRepository;
            this.mapper = mapper;
        }

        private HashSet<string> allowedOrderByQueries = new HashSet<string>()
        {
            "id",
            "name",
            "lastname",
            "nationallity"
        };


        public IEnumerable<Author> GetAuthors(string orderBy, bool showBooks)
        {
            orderBy = orderBy.ToLower();
            if (!allowedOrderByQueries.Contains(orderBy))
            {
                throw new InvalidOperationException($"Invalid \" {orderBy} \" orderBy query param. The allowed values are {string.Join(",", allowedOrderByQueries)}");
            }

            var authors = authorsRepository.GetAuthors();

            foreach (var author in authors)
            {
                if (showBooks)
                {
                    author.books = authorsRepository.GetBooks().Where(b => b.AuthorId == author.Id);
                }
                else
                {
                    author.books = null;
                }
            }

            switch (orderBy)
            {
                case "id":
                    return authors.OrderBy(a => a.Id);
                case "name":
                    return authors.OrderBy(a => a.Name);
                case "lastname":
                    return authors.OrderBy(a => a.LastName);
                case "nationallity":
                    return authors.OrderBy(a => a.Name);
                default:
                    return authors;
            }
        }

        public Author GetAuthor(int id, bool showBooks)
        {
            var author = authorsRepository.GetAuthor(id);

            if (author == null)
            {
                throw new NotFoundException("author not found");
            }

            if (showBooks)
            {
                author.books = authorsRepository.GetBooks().Where(b => b.AuthorId == author.Id);
            }
            else
            {
                author.books = null;
            }

            return author;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            var authorEntity = mapper.Map<AuthorEntity>(author);

            authorsRepository.CreateAuthor(authorEntity);
            if (await authorsRepository.SaveChangesAsync())
            {
                return mapper.Map<Author>(authorEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        public Author UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                throw new InvalidOperationException("URL id needs to be the same as Author id");
            }

            var authorToUpdate = authorsRepository.GetAuthor(id);
            if (authorToUpdate == null)
            {
                throw new NotFoundException("invalid author to update");
            }

            author.Id = id;
            return authorsRepository.UpdateAuthor(author);
        }

        public bool DeleteAuthor(int id)
        {
            var authorToDelete = authorsRepository.GetAuthors().SingleOrDefault(a => a.Id == id);
            if (authorToDelete == null)
            {
                throw new NotFoundException("invalid author to delete");
            }
            return authorsRepository.DeleteAuthor(id);
        }
    }
}
