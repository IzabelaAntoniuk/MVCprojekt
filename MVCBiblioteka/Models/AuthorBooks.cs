using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class AuthorBooks
    {
        [Key]
        public int AuthorBooksID { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}