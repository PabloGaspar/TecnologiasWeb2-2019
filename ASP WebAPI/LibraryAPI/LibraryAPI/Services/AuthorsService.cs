using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class AuthorsService : IAuthorsService
    {
        private List<Author> authors = new List<Author>();

        public AuthorsService()
        {
            authors.Add(new Author() {
                Id = 1,
                Age = 44,
                LastName  = "Saint-Exupery",
                Name = "Antoine",
                Nationallity = "France"
            });

            authors.Add(new Author()
            {
                Id = 2,
                Age = 85,
                LastName = "Tolkien",
                Name = "JRR",
                Nationallity = "South Africa",
            });

            authors.Add(new Author()
            {
                Id = 3,
                Age = 75,
                LastName = "Lovecraft",
                Name = "HP",
                Nationallity = "USA",
            });
        }

        private HashSet<string> allowedOrderByQueries = new HashSet<string>()
        {
            "id",
            "name",
            "lastname",
            "nationallity"
        };


        public IEnumerable<Author> GetAuthors(string orderBy)
        {

            orderBy = orderBy.ToLower();
            if (!allowedOrderByQueries.Contains(orderBy))
            {
                throw new InvalidOperationException($"Invalid \" {orderBy} \" orderBy query param. The allowed values are {string.Join(",", allowedOrderByQueries)}");
            }

            var authors = this.authors;

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
                    return this.authors;
            }
        }

        public Author GetAuthor(int id)
        {
            return authors.FirstOrDefault(a => a.Id == id);
        }

        public Author AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Author UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
