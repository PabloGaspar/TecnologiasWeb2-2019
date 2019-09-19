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
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsService authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors(bool showBooks = false, string orderBy = "id")
        {
            try
            {
                return Ok(await authorsService.GetAuthorsAsync(showBooks, orderBy));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorAsync(int id, bool showBooks = false )
        {
            try
            {
                var author = await authorsService.GetAuthorAsync(id, showBooks);
                return Ok(author);

            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
            
        }
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAuthor = await authorsService.CreateAuthorAsync(author);
            return Created($"/api/authors/{createdAuthor.id}", createdAuthor);
        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<bool>> DeleteAuthor(int Id)
        {
            try
            {
                return Ok(await this.authorsService.DeleteAuthorAsync(Id));
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<Author> PutAuthor(int id, [FromBody]Author author )
        {
            if (!ModelState.IsValid)
            {
                var natinallity = ModelState[nameof(author.Nationallity)];
                
                if (natinallity != null && natinallity.Errors.Any())
                {
                    return BadRequest(natinallity.Errors);
                }
            }

            try
            {
                return Ok(authorsService.UpdateAuthor(id, author));

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
