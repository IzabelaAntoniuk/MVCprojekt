using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class BookState
    {
        [Key]
        public int BookStateID { get; set; }

        [Required]
        [Display(Name = "Status książki: ")]
        public string state { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}