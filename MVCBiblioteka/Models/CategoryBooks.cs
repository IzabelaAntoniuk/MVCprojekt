using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class CategoryBooks
    {
        [Key]
        public int CategoryBooksID { get; set;}
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Book Book { get; set; }
    }
}