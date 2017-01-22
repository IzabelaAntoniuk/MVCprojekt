using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        [Display(Name = "Imię: ")]
        [Required]
        public string name { get; set; }
        [Required]
        [Display(Name = "Nazwisko: ")]
        public string surname { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Pełne imię: ")]
        public string allname { get; set; }
        [ScaffoldColumn(false)]
        [Required]
        public int BookID { get; set; }
        [Display(Name = "Data urodzenia: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        public DateTime birthDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy.MM.dd}")]
        [ScaffoldColumn(false)]
        [Display(Name = "Data śmierci: ")]
        public DateTime? deathDate { get; set; }
        [Display(Name = "Biografia: ")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string description { get; set; }
        
        public virtual ICollection<AuthorBooks> AuthorBooks { get; set; }
    }
}