using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class Book
    {
        public int BookID { get; set; }
        [Required]
        [Display(Name = "Tytuł: ")]
        public string title { get; set; }
        [Required]
        [Display(Name = "Data premiery: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime premiereDate { get; set; }
        [Required]
        [Display(Name = "Wydawnictwo: ")]
        public int PublisherID { get; set; }
        [Required]
        [Display(Name = "Autor: ")]
        public int AuthorID { get; set; }
        [Required]
        [Display(Name = "Gatunek: ")]
        public int CategoryID { get; set; }
        [Required]
        [Display(Name = "Opis: ")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Status książki: ")]
        public int BookStateID { get; set; }
        [Required]
        public string ISBN { get; set; }

        //[Required]
        //[Display(Name = "Status: ")]
        //public int BookStateID { get; set; }

        public virtual ICollection<PublisherBooks> PublishersBooks { get; set; }
        public virtual ICollection<AuthorBooks> AuthorsBooks { get; set; }
        public virtual ICollection<CategoryBooks> CategoryBooks { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual BookState BookState { get; set; }
    }
}