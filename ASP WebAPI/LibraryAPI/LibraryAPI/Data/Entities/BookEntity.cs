using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Data.Entities
{
    public class BookEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Tittle { get; set; }
        public int Pages { get; set; }
        [Required]
        public string Genre { get; set; }

        [ForeignKey("AuthorId")]
        public virtual AuthorEntity Author { get; set; }
    }
}
