using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int? Id { get; set; }
        [Required]
        public string Tittle { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }
        public int? AuthorId { get; set; }
    }
}
