using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class Cart
    {
        [Key]
        public int RecordID { get; set; }
        public string CartID { get; set; }
        public int BookID { get; set; }
        [Display(Name = "Ilość: ")]
        public int Count { get; set; }
        [Display(Name = "Data utworzenia: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public System.DateTime DateCreated { get; set; }
        public virtual Book Book { get; set; }
    }
}