using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Author
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nationallity { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public IEnumerable<Book> books { get; set; }
    }
}
