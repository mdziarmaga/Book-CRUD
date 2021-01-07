using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Date of production")]
        public DateTime? ProductionDate { get; set; }
        [Required(ErrorMessage ="Enter a author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Enter a category")]
        public string Category { get; set; }
    }
}