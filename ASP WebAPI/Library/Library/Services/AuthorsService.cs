using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Repository;
using Library.Exceptions;
using Library.Models;

namespace Library.Services
{
    

    public class AuthorsService : IAuthorsService
    {
        private HashSet<string> allowedOrderByValues;
        private ILibraryRepository libraryRepository;
        public AuthorsService(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
            allowedOrderByValues = new HashSet<string>() { "name", "lastname", "age", "id" };
        }

        public Author CreateAuthor(Author newAuthor)
        {
            newAuthor.id = 0;
           return  libraryRepository.CreateAuthor(newAuthor);
        }

        public bool DeleteAuthor(int id)
        {
            var authorToDelete = libraryRepository.GetAuthor(id);
            if (authorToDelete == null)
            {
                throw new NotFoundItemException($"author {id} does not exists");
            }
            return libraryRepository.DeleteAuhor(id);
        }

        public Author GetAuthor(int id, bool showBooks)
        {
            validatAuthorId(id);
            var author = libraryRepository.GetAuthor(id, showBooks);
            return author;
        }

        public IEnumerable<Author> GetAuthors(string orderBy)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower))
            {
                throw new BadRequestOperationException($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }
            var authors = libraryRepository.GetAuthors();
            switch (orderByLower)
            {
                case "name":
                    return authors.OrderBy(a => a.Name);
                case "lastname":
                    return authors.OrderBy(a => a.LastName);
                case "age":
                    return authors.OrderBy(a => a.Age);
                default:
                    return authors.OrderBy(a => a.id); ;
            }
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

        private Author validatAuthorId(int id, bool showBooks = false)
        {
            var author = libraryRepository.GetAuthor(id);
            if (author == null)
            {
                throw new NotFoundItemException($"cannot found author with id {id}");
            }
            
            return author;
        }
    }
}
