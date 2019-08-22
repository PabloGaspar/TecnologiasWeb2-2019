using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Services
{
    

    public class AuthorsService : IAuthorsService
    {
        private List<Author> authors;

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
            throw new NotImplementedException();
        }

        public List<Author> GetAuthors()
        {
            return authors;
        }

        public Author UpdateAuthor(Author newAuthor)
        {
            throw new NotImplementedException();
        }
    }
}
