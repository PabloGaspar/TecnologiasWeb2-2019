using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Exceptions;
using Library.Models;

namespace Library.Services
{
    

    public class AuthorsService : IAuthorsService
    {
        private List<Author> authors;
        private HashSet<string> allowedOrderByValues;
        public AuthorsService()
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

            allowedOrderByValues = new HashSet<string>() { "name", "lastname", "age", "id" };
        }

        public Author CreateAuthor(Author newAuthor)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(int id)
        {
            var author = authors.SingleOrDefault(a => a.id == id);
            if (author == null)
            {
                throw new NotFoundItemException($"cannot found author with id {id}");
            }

            return author;
        }

        public IEnumerable<Author> GetAuthors(string orderBy)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower))
            {
                throw new BadRequestOperationException($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }

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

        public Author UpdateAuthor(Author newAuthor)
        {
            throw new NotImplementedException();
        }
    }
}
