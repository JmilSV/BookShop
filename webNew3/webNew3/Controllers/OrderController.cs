using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webNew3.Models;

namespace webNew3.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            MyCart cart = MyCart.GetCart();

            if (cart.BookCarts.Count > 0)
            {
                for (int i = 0; i < cart.BookCarts.Count; i++)
                {
                    if (i == 0)
                    {
                        orderViewModel.customerOrders = new List<CustomerOrder>();
                        orderViewModel.books = new List<Book>();
                    }
                    orderViewModel.customerOrders.Add(new CustomerOrder
                    { 
                        BookId = cart.BookCarts[i].book.BookId,
                        Price = cart.BookCarts[i].book.Price,
                        Quantity = cart.BookCarts[i].amount
                    });
                    orderViewModel.books.Add(cart[i].book);
                }
            }
            orderViewModel.cost = cart.Cost;

            return View(orderViewModel);
        }

        [HttpPost]
        public ActionResult Create(OrderViewModel orderViewModel)
        {
            BookDbContext bookDbContext = new BookDbContext();

            if (ModelState.IsValid)
            {
                bookDbContext.Customers.Add(new Customer
                {
                    FirstName = orderViewModel.FirstName,
                    LastName = orderViewModel.LastName
                });
                bookDbContext.SaveChanges();

                int customerId = bookDbContext.Customers.FirstOrDefault(x => x.LastName == 
                    orderViewModel.LastName && x.FirstName == orderViewModel.FirstName).CustomerId;

                bookDbContext.CustomerAdresses.Add(new CustomerAdress
                {
                    Country = orderViewModel.Country,
                    CityOrVillage = orderViewModel.CityOrVillage,
                    Street = orderViewModel.Street,
                    House = orderViewModel.House,
                    Appartment = orderViewModel.Appartment,
                    CustomerId = customerId
                });

                MyCart cart = MyCart.GetCart();

                for (int i = 0; i < cart.bookCartCount; i++)
                {
                    bookDbContext.CustomerOrders.Add(new CustomerOrder
                    {
                        CustomerId = customerId,
                        BookId = cart[i].book.BookId,
                        Price = cart[i].book.Price,
                        Quantity = cart[i].amount,
                        OrderDateTime = DateTime.Now
                    });
                }
                bookDbContext.SaveChanges();

                return View("Success", cart);
            }
            return View("Fall");
        }
	}
}