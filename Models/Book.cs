using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookshop.Models
{
    public class Book
    {
        [Key]
        [ScaffoldColumn(false)]
        public int IdBook { get; set; }
        [Required(ErrorMessage = "Enter the title")]
        public string Tittle { get; set; }
        public DateTime? ProductionDate { get; set; }
        [Required(ErrorMessage ="Enter a author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Enter a category")]
        public string Category { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? CheckOutDate { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? ReturnDate { get; set; }
    }
}