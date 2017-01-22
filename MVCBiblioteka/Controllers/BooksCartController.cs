using MVCBiblioteka.Models;
using MVCBiblioteka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBiblioteka.Controllers
{
    public class BooksCartController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();

        public ActionResult Index()
        {
            var cart = BooksCart.GetCart(this.HttpContext);
            
            var viewModel = new BooksCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {

            var addedBook = storeDB.Books
                .Single(book => book.BookID == id);

            var cart = BooksCart.GetCart(this.HttpContext);

            cart.AddToCart(addedBook);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            var cart = BooksCart.GetCart(this.HttpContext);

            string bookName = storeDB.Carts.Single(item => item.RecordID == id).Book.title;

            int itemCount = cart.RemoveFromCart(id);

            var results = new BooksCartRemoveViewModel
            {
                Message = Server.HtmlEncode(bookName) +
                    " - usunięto z koszyka.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = BooksCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}