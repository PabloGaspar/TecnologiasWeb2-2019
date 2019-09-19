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
    

    public class AuthorsService : IAuthorsService
    {
        private HashSet<string> allowedOrderByValues;
        private ILibraryRepository libraryRepository;
        private readonly IMapper mapper;
        public AuthorsService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            this.libraryRepository = libraryRepository;
            this.mapper = mapper;
            allowedOrderByValues = new HashSet<string>() { "name", "lastname", "age", "id" };
        }

        public async Task<Author> CreateAuthorAsync(Author newAuthor)
        {
            var authorEntity = mapper.Map<AuthorEntity>(newAuthor);
            libraryRepository.CreateAuthor(authorEntity);
            if (await libraryRepository.SaveChangesAsync())
            {
                return mapper.Map<Author>(authorEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            await validatAuthorId(id);
            await libraryRepository.DeleteAuthorAsync(id);
            if(await libraryRepository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<Author> GetAuthorAsync(int id, bool showBooks)
        {
            //validatAuthorId(id);
            //var author = libraryRepository.GetAuthor(id, showBooks);
            //return author;
            var author = await libraryRepository.GetAuthorAsync(id, showBooks);

            if (author == null)
            {
                throw new NotFoundItemException("author not found");
            }

            return mapper.Map<Author>(author);

        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync(bool showBooks, string orderBy)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower))
            {
                throw new BadRequestOperationException($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }
            var authorsEntities = await libraryRepository.GetAuthorsAsync(showBooks, orderByLower);
            return mapper.Map<IEnumerable<Author>>(authorsEntities);
        }

        public Author UpdateAuthor(int id, Author newAuthor)
        {
            //nada  q ver
            validatAuthorId(id);

            if (newAuthor.id == null)
            {
                newAuthor.id = id;
            }
            if (id != newAuthor.id)
            {
                throw new BadRequestOperationException("id URL should be euqual to body");
            }
            newAuthor.id = id;

            return libraryRepository.UpdateAuthor(newAuthor);
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
    }
}
