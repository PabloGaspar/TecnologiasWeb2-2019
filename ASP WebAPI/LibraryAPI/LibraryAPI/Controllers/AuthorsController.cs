﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Exceptions;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using InvalidOperationException = LibraryAPI.Exceptions.InvalidOperationException;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsService authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get(string orderBy = "Id")
        {
            try
            {
                return Ok(authorsService.GetAuthors(orderBy));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");

            }
        }

        [HttpGet("{authorId}")]
        public ActionResult<Author> Get(int authorId)
        {
            try
            {
                var author = this.authorsService.GetAuthor(authorId);
                return Ok(author);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Author> Post(Author author)
        {
            var postedAuthor = this.authorsService.AddAuthor(author);
            return Created($"/api/authors/{postedAuthor.Id}", postedAuthor);
        }

        [HttpDelete("{authorId}")]
        public ActionResult<bool> Delete(int authorId)
        {
            try
            {
                return Ok(this.authorsService.DeleteAuthor(authorId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

        [HttpPut("{authorId}")]
        public ActionResult<Author> Update(int authorId, Author author)
        {
            try
            {
                return Ok(this.authorsService.UpdateAuthor(authorId, author));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
    }
}
