using Microsoft.AspNet.Identity;
using MVCBiblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCBiblioteka.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        const string PromoCode = "HURA";

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    var userIdd = User.Identity.GetUserId();
                    if (userIdd == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    order.UserID = userIdd;
                    order.OrderDate = DateTime.Now;
                    order.Username = User.Identity.Name;

                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();

                    var cart = BooksCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderID });
                }
            }
            catch
            {

                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {
            bool isValid = storeDB.Orders.Any(
                o => o.OrderID == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                ModelState.Clear();
                return View("Error");
            }
        }

    }
}