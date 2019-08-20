using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
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
                /*int a = 0;
                int b = 2;
                int c = b / a;*/
                /*var authors = new List<string>()
                {
                    "Tolkien",
                    "Lovecraft"
                };

                return Ok(authors);*/

                return Ok(authorsService.GetAuthors(orderBy));
            }
            catch(InvalidOperationException ex)
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

                if (author == null)
                {
                    return NotFound($"the author with id {authorId} does not exist");
                }

                return Ok(author);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
    }
}
