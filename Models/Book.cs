
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Models;

namespace Library.Models{

    public class Book{
        [Key]
        public int Id_Book { get; set; }
        public string Title{get; set;}

        public string Description{get; set;}
        public string Section { get; set; }
        public string Genre { get; set; }
        public int Year{get; set;}

        public string Publisher { get; set; }

    }
}