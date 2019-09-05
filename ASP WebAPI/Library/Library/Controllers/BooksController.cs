using Library.Exceptions;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/authors/{authorId:int}/books")]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;
        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }
        [HttpGet()]
        public ActionResult<IEnumerable<Book>> getBooks(int authorId)
        {
            try
            {
                var books = booksService.GetBooks(authorId);
                return Ok(books);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost()]
        public ActionResult<Book> PostBook(int authorId, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var bookCreated = booksService.AddBook(authorId, book);
                return Created($"/api/authors/{authorId}/books/{book.Id}", bookCreated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Book> PutBook(int authorId, int id, [FromBody] Book book)
        {
            try
            {
                return booksService.EditBook(authorId, id, book);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
