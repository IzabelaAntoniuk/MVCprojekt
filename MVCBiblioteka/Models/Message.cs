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
        public string msg { get; set; }
    }
}