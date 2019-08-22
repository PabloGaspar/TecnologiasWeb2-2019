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
    public class AuthorsController: ControllerBase
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
            catch(BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            try
            {
                return Ok(authorsService.GetAuthor(id));
            }
            catch(NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message); 
            }
        }
    }
}
