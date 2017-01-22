using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBiblioteka.Models
{
    public partial class BooksCart
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        [Key]
        public string BooksCartID { get; set; }
        public const string CartSessionKey = "CartId";
        public static BooksCart GetCart(HttpContextBase context)
        {
            var cart = new BooksCart();
            cart.BooksCartID = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static BooksCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Book book)
        {
            // Get the matching cart and album instances
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartID == BooksCartID
                && c.BookID == book.BookID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    BookID = book.BookID,
                    CartID = BooksCartID,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Count++;
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.Carts.Single(
                cart => cart.CartID == BooksCartID
                && cart.RecordID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }
                // Save changes
                storeDB.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(
                cart => cart.CartID == BooksCartID);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public List<Cart> GetCartItems()
        {
            return storeDB.Carts.Where(
                cart => cart.CartID == BooksCartID).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CartID == BooksCartID
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            int? total = (from cartItems in storeDB.Carts
                              where cartItems.CartID == BooksCartID
                              select (int?)cartItems.Count).Sum();
            //cartItems.Book.AuthorID).Sum();

            return total ?? 0;// ?? decimal.Zero;
        }
        public int CreateOrder(Order order)
        {
            //decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    BookID = item.BookID,
                    OrderID = order.OrderID,
                    lendDate = DateTime.Now.Date,
                    returnDate = DateTime.Now.AddDays(14),
                    // UnitPrice = item.Book.,
                    Quantity = item.Count,
                    UserID = order.UserID,
                    username = order.Username
                };
                // Set the order total of the shopping cart
               // orderTotal += (item.Count * item.Album.Price);

                storeDB.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            //order.Total = orderTotal;

            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderID;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carts.Where(
                c => c.CartID == BooksCartID);

            foreach (Cart item in shoppingCart)
            {
                item.CartID = userName;
            }
            storeDB.SaveChanges();
        }
    }
}