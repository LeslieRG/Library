using System.ComponentModel.DataAnnotations;

namespace Library.Models{
    public class Author{
        [Key]
        public int Id_Author { get; set; }
        public string Name { get; set; }
        public string Last_Name{get; set;}
        public string Email{get; set;}
    }
}