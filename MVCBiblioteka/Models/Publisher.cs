using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBiblioteka.Models
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        [Required]
        [Display(Name = "Nazwa wydawnictwa: ")]
        public string name { get; set; }
        [Display(Name = "Strona internetowa: ")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string website { get; set; }
        [Display(Name = "Opis: ")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string description { get; set; }
        public int BookID { get; set; }

        public virtual ICollection<PublisherBooks> PublisherBooks { get; set; }
    }
}