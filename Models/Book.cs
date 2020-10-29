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
        public int IdBook { get; set; }
        [Required(ErrorMessage = "Enter the title")]
        public string Tittle { get; set; }
    }
}