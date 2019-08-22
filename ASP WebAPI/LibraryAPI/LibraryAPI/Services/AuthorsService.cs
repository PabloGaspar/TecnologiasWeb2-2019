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
            var author =  authors.SingleOrDefault(a => a.Id == id);

            if (author == null)
            {
                throw new NotFoundException("author not found");
            }
            return author;
        }

        public Author AddAuthor(Author author)
        {
            var nextId = authors.OrderByDescending(a => a.Id).FirstOrDefault().Id + 1;
            author.Id = nextId;
            authors.Add(author);
            return author;
        }

        public Author UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                throw new InvalidOperationException("URL id needs to be the same as Author id");
            }

            var authorToUpdate = authors.SingleOrDefault(a => a.Id == author.Id);
            if (authorToUpdate == null)
            {
                throw new NotFoundException("invalid author to update");
            }

            authorToUpdate.LastName = author.LastName;
            authorToUpdate.Name = author.Name;
            authorToUpdate.Nationallity = author.Nationallity;
            authorToUpdate.Age = author.Age;
            return author;
        }

        public bool DeleteAuthor(int id)
        {
            var authorToDelete = authors.SingleOrDefault(a => a.Id == id);
            if (authorToDelete == null)
            {
                throw new NotFoundException("invalid author to delete");
            }
            authors.Remove(authorToDelete);
            return true;
        }
    }
}
