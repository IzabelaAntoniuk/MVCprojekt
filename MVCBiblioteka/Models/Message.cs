using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [Display(Name = "Treść: ")]
        public string msg { get; set; }
        [Display(Name = "Data: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime date { get; set; }
    }
}