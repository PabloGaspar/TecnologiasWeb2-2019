﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Entities
{
    public class AuthorEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nationallity { get; set; }
        public int Age { get; set; }
        public virtual ICollection<BookEntity> Books { get; set; }
    }
}
