using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/authors/{authorId:int}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get(int authorId)
        {
            try
            {
                return Ok(booksService.GetBooks(authorId));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<Book>> Get(int authorId, int id)
        {
            try
            {
                return Ok(booksService.GetBook(authorId, id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}
