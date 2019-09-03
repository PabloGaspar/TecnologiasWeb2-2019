using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author
    {
        public int? id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,120)]
        public int Age { get; set; }
        [Required]
        public string LastName { get; set; }
        [StringLength(20, ErrorMessage = "error {0} There isn't a country name with more than {1} min is {2}", MinimumLength = 2)]
        public string Nationality { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
