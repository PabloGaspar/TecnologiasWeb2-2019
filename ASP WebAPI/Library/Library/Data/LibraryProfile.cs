using AutoMapper;
using Library.Data.Entities;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            this.CreateMap<AuthorEntity, Author>()
                .ReverseMap();

            this.CreateMap<BookEntity, Book>()
                .ReverseMap();
        }
    }
}
