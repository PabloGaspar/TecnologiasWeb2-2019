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
        public ActionResult<List<string>> GetAuthors()
        {
            try
            {
                return Ok(authorsService.GetAuthors());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");
            }


            
        }
    }
}
