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
        public ActionResult<IEnumerable<Author>> GetAuthors(string orderBy = "id")
        {
            try
            {
                return Ok(authorsService.GetAuthors(orderBy));
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
        public ActionResult<Author> GetAuthor(int id, bool showBooks = false )
        {
            try
            {
                return Ok(authorsService.GetAuthor(id, showBooks));
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
        [HttpPost]
        public ActionResult<Author> PostAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAuthor = authorsService.CreateAuthor(author);
            return Created($"/api/authors/{createdAuthor.id}", createdAuthor);
        }
        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteAuthor(int id)
        {
            try
            {
                var result = authorsService.DeleteAuthor(id);
                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError, "cannot delete author");
                return Ok(result);
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
        public ActionResult<Author> PutAuthor(int id, [FromBody]Author author )
        {
            if (!ModelState.IsValid)
            {
                var natinallity = ModelState[nameof(author.Nationality)];
                
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
