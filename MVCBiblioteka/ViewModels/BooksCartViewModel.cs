using MVCBiblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBiblioteka.ViewModels
{
    public class BooksCartViewModel
    {
        public string BooksCartViewModelID { get; set; }
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}