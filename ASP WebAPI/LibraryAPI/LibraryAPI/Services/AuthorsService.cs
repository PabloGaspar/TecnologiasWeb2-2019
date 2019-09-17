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


        public async Task<IEnumerable<Author>> GetAuthorsAsync(string orderBy, bool showBooks)
        {
            orderBy = orderBy.ToLower();
            if (!allowedOrderByQueries.Contains(orderBy))
            {
                throw new InvalidOperationException($"Invalid \" {orderBy} \" orderBy query param. The allowed values are {string.Join(",", allowedOrderByQueries)}");
            }

            var authorsEntities = await authorsRepository.GetAuthors(orderBy, showBooks);
            return mapper.Map<IEnumerable<Author>>(authorsEntities);
        }

        public async Task<Author> GetAuthorAsync(int id, bool showBooks)
        {
            var authorEntity = await authorsRepository.GetAuthorAsync(id, showBooks);

            if (authorEntity == null)
            {
                throw new NotFoundException("author not found");
            }

            return mapper.Map<Author>(authorEntity);
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

        public async Task<Author> UpdateAuthorAsync(int id, Author author)
        {
            if (id != author.Id)
            {
                throw new InvalidOperationException("URL id needs to be the same as Author id");
            }
            await ValidateAuthor(id);

            author.Id = id;
            var authorEntity = mapper.Map<AuthorEntity>(author);
            authorsRepository.UpdateAuthor(authorEntity);
            if (await authorsRepository.SaveChangesAsync())
            {
                return mapper.Map<Author>(authorEntity);
            }

            throw new Exception("There were an error with the DB");


        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            await ValidateAuthor(id);
            await authorsRepository.DeleteAuthorAsync(id);
            if (await authorsRepository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        private async Task  ValidateAuthor(int id)
        {
            var author = await authorsRepository.GetAuthorAsync(id);
            if (author == null)
            {
                throw new NotFoundException("invalid author to delete");
            }
            authorsRepository.DetachEntity(author);
        }
    }
}
