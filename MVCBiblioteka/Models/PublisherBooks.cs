using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class PublisherBooks
    {
        [Key]
        public int PublisherBooksID { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Book Book { get; set; }
    }
}