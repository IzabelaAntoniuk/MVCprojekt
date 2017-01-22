using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Display(Name = "Nazwa: ")]
        public string name { get; set; }

        public virtual ICollection<CategoryBooks> CategoryBooks { get; set; }
    }
}