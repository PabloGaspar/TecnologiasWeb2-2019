using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesAPI.Moldels;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            var games = new List<Game>() {
                new Game()
                {
                    Id = 1,
                    Name = "Dark Souls",
                    Price = 50,
                    Genre = "RPG",
                    Rate = "M"
                },
                new Game()
                {
                    Id = 2,
                    Name = "Smash Bross",
                    Genre = "Figthing",
                    Price = 60,
                    Rate = "E"
                }
            };

            return Ok(games);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Game game)
        {
            Console.WriteLine(game);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
