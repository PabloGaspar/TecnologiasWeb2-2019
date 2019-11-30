using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesAPI.Moldels
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
