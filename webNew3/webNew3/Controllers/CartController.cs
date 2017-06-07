using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webNew3.Models;


namespace webNew3.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Basket/
        public ActionResult Index()
        {
            MyCart cart = MyCart.GetCart();
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddBook(int bookId)
        {
            BookDbContext bookDbContext = new BookDbContext();
            Book book = bookDbContext.Books.Find(bookId);
            MyCart cart = MyCart.GetCart();
            int result;
            if (book != null)
            {
                result = cart.AddBook(book);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult RemoveBook(int bookId)
        {
            BookDbContext bookDbContext = new BookDbContext();
            Book book = bookDbContext.Books.Find(bookId);
            MyCart cart = MyCart.GetCart();
            int result;
            if (book != null)
            {
                result = cart.RemoveBook(book);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult IncrementAmount(int bookId)
        {
            BookDbContext bookDbContext = new BookDbContext();
            Book book = bookDbContext.Books.Find(bookId);
            MyCart cart = MyCart.GetCart();
            int result;
            if (book != null)
            {
                result = cart.IncrementAmount(book);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DecrementAmount(int bookId)
        {
            BookDbContext bookDbContext = new BookDbContext();
            Book book = bookDbContext.Books.Find(bookId);
            MyCart cart = MyCart.GetCart();
            int result;
            if (book != null)
            {
                result = cart.DecrementAmount(book);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Clear()
        {
            MyCart cart = MyCart.GetCart();
            cart.Clear();
            return RedirectToAction("Index");
        }
	}
}