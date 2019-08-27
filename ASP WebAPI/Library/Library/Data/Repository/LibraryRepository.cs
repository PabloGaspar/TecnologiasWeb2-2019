using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<Author> authors;
        public LibraryRepository()
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
        public Author CreateAuthor(Author author)
        {
            var lastAuthor = authors.OrderByDescending(a => a.id).FirstOrDefault();
            var nextID = lastAuthor == null ? 1 : lastAuthor.id + 1;
            author.id = nextID;
            authors.Add(author);
            return author;
        }

        public bool DeleteAuhor(int id)
        {
            var authorToDelete = authors.Single(a => a.id == id);
            return authors.Remove(authorToDelete);
        }

        public Author GetAuthor(int id)
        {
            return authors.SingleOrDefault(a => a.id == id);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authors;
        }

        public Author UpdateAuthor(Author author)
        {
            var authorToUpdate = authors.Single(a => a.id == author.id);
            authorToUpdate.LastName = author.LastName;
            authorToUpdate.Name = author.Name;
            authorToUpdate.Age = author.Age;
            authorToUpdate.Nationality = author.Nationality;

            return authorToUpdate;


        }
    }
}
