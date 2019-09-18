﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<Author> authors;
        private List<Book> books;
        private LibraryDbContext libraryDbContext;
        public LibraryRepository(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
            authors = new List<Author>()
            {
                new Author()
                {
                    id = 1,
                    LastName = "Tolkien",
                    Age = 87,
                    Name = "JRR",
                    Nationallity = "south africa"
                },
                new Author()
                {
                    id = 2,
                    LastName = "King",
                    Age = 65,
                    Name = "Sthephen",
                    Nationallity = "USA"
                }

            };

            books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    AuthorId = 1,
                    Genre = "Fantasy",
                    Pages = 400,
                    Tittle = "The Silmarillon"

                },
                new Book()
                {
                    Id = 2,
                    AuthorId = 1,
                    Genre = "Fantasy",
                    Pages = 300,
                    Tittle = "The Lord of the Rings"

                },
                new Book()
                {
                    Id = 3,
                    AuthorId = 2,
                    Genre = "Horror",
                    Pages = 300,
                    Tittle = "It"
                },
                new Book()
                {
                    Id = 4,
                    AuthorId = 2,
                    Genre = "Horror",
                    Pages = 300,
                    Tittle = "The Shining"
                }
            };

        }
        public void CreateAuthor(AuthorEntity author)
        {
            libraryDbContext.Authors.Add(author);
        }

        public Book CreateBook(Book book)
        {
            var latestBook = books.OrderByDescending(b => b.Id).FirstOrDefault();
            var nextBookId = latestBook == null ? 1 : latestBook.Id + 1;
            book.Id = nextBookId;
            books.Add(book);
            return book;
        }

        public bool DeleteAuhor(int id)
        {
            var authorToDelete = authors.Single(a => a.id == id);
            return authors.Remove(authorToDelete);
        }

        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorEntity> GetAuthorAsync(int id, bool showBooks)
        {
            //var author = authors.SingleOrDefault(a => a.id == id);
            //if (showBooks)
            //{
            //    author.Books = books.Where(b => b.AuthorId == id);

            //}
            //return author;
            IQueryable<AuthorEntity> query = libraryDbContext.Authors;

            if (showBooks)
            {
                query = query.Include(a => a.Books);
            }

            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AuthorEntity>> GetAuthorsAsync(bool showBooks, string orderBy)
        {
            IQueryable<AuthorEntity> query = libraryDbContext.Authors;
            if (showBooks)
            {
                query = query.Include(a => a.Books);
            }
            
            switch (orderBy)
            {
                case "name":
                    query = query.OrderBy(a => a.Name);
                    break;
                case "lastname":
                    query = query.OrderBy(a => a.LastName);
                    break;
                case "age":
                    query = query.OrderBy(a => a.Age);
                    break;
                default:
                    query = query.OrderBy(a => a.Id);
                    break;
            }

            return await query.ToArrayAsync();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await libraryDbContext.SaveChangesAsync()) > 0;
        }

        public Author UpdateAuthor(Author author)
        {
            var authorToUpdate = authors.Single(a => a.id == author.id);
            authorToUpdate.LastName = author.LastName;
            authorToUpdate.Name = author.Name;
            authorToUpdate.Age = author.Age;
            authorToUpdate.Nationallity = author.Nationallity;

            return authorToUpdate;


        }

        public Book UpdateBook(Book book)
        {
            var bookToUpdate = books.Single(b => b.Id == book.Id);
            bookToUpdate.Pages = book.Pages;
            bookToUpdate.Tittle = book.Tittle;
            bookToUpdate.Genre = book.Genre;
            return bookToUpdate;
        }
    }
}
