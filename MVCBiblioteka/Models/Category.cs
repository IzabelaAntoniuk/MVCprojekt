using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Display(Name = "Nazwa: ")]
        public string name { get; set; }

        [Display(Name = "Nadkategoria: ")]
        public int? fatherCategoryID { get; set; }

        [ForeignKey("fatherCategoryID")]
        public Category FatherCategory { get; set; }

        public virtual ICollection<CategoryBooks> CategoryBooks { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}