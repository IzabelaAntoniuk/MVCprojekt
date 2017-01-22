using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBiblioteka.Models
{
    [Bind(Exclude = "OrderID")]
    public partial class Order
    {
        [ScaffoldColumn(false)]
        public int OrderID { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Imię jest obowiązkowe!")]
        [DisplayName("Imię: ")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest obowiązkowe!")]
        [DisplayName("Nazwisko: ")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email jest obowiązkowy!")]
        [DisplayName("Email: ")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email jest zajęty.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public string UserID { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}