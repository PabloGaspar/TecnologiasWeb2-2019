using Library.Exceptions;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/authors/{authorId:int}/books")]
    public class BooksController: ControllerBase
    {
        private IBooksService booksService;
        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }
        [HttpGet]
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
    }
}
