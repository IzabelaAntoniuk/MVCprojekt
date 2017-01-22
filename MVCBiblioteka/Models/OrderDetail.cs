using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public string username { get; set; }
        public string UserID { get; set; }
        [Display(Name = "Ilość: ")]
        public int Quantity { get; set; }
        [Display(Name = "Data wypożyczenia: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime lendDate { get; set; }
        [Display(Name = "Data zwrotu: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime returnDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}