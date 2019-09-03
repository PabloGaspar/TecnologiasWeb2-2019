using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Author
    {
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        [StringLength(20, ErrorMessage = "{0} must be at most {1}  characters")]
        public string Nationallity { get; set; }
        [Range(1,110)]
        public int Age { get; set; }
        public int Id { get; set; }
        public IEnumerable<Book> books { get; set; }
    }
}
