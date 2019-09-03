using AutoMapper;
using LibraryAPI.Data.Entities;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Data
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
