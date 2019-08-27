using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author
    {
        public int? id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
    }
}
