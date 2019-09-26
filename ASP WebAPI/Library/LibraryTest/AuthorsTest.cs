using AutoMapper;
using Library.Data;
using Library.Data.Entities;
using Library.Data.Repository;
using Library.Exceptions;
using Library.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LibraryTest
{
    public class UnitTest1
    {
        [Fact]
        public void AuthorService_ShouldReturnExceptionIfNotFound()
        {
            //arrange
            int authorId = 22;
            var MoqlibraryRespository = new Mock<ILibraryRepository>();
            var authorEntity = new AuthorEntity() { Id = 1, Age = 22, Name = "blalfal" };
            MoqlibraryRespository.Setup(m => m.GetAuthorAsync(1, false)).Returns(Task.FromResult(authorEntity));

            var myProfile = new LibraryProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            var authorService = new AuthorsService(MoqlibraryRespository.Object, mapper);
            //act 
            Assert.ThrowsAsync<NotFoundItemException>( () => authorService.GetAuthorAsync(1, false));
        }
    }
}
