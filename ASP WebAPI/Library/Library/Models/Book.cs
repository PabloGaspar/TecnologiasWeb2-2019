﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
    }
}
