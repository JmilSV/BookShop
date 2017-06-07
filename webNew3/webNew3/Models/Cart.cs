using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webNew3.Models
{
    public class MyCart
    {
        decimal cost;
        public decimal Cost{
            get
            {
                cost = 0;
                foreach (BookCart bookCart in bookCarts)
                {
                    cost += bookCart.sum;
                }
                return cost;
            }
        }

        static MyCart cart;
        private MyCart(){ }
        public static MyCart GetCart()
        {
            if (cart == null)
            {
                cart = new MyCart();
                return cart;
            }
            else
            {
                return cart;
            }
        }

        List<BookCart> bookCarts = new List<BookCart>();

        public List<BookCart> BookCarts
        {
            get 
            {
                return bookCarts; 
            }
        }
        public int bookCartCount
        {
            get
            {
                return bookCarts.Count;
            }
        }

        public BookCart this[int index]
        {
            get
            {
                return bookCarts[index];
            }
        }

        /// <summary>
        /// Додати книгу або збільшити кількість товару. Невдача - вертається '-1'
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddBook(Book book)
        {
            if(book != null)
            {
                if (bookCarts.Count == 0 ||
                    bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId) == null)
                {
                    bookCarts.Add(new BookCart(book));
                    return 0;
                }
                else
                {
                    bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId).amount++;
                    return 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Bидалити книгу (всю позицію). Невдача - вертається '-1'
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int RemoveBook(Book book)
        {
            if (book != null)
            {
                if (bookCarts.Count != 0 ||
                    bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId) != null)
                {
                    bookCarts.Remove(bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId));
                    return 0;
                }
            }
            return -1;
        }
        public int IncrementAmount(Book book)
        {
            if (book != null && bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId) != null)
            {
                bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId).amount++;
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public int DecrementAmount(Book book)
        {
            if (book != null && bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId) != null)
            {
                if (bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId).amount > 1)
                {
                    bookCarts.FirstOrDefault(b => b.book.BookId == book.BookId).amount--;
                    return 0;
                }
                else
                {
                    int result = RemoveBook(book);
                    return result;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Видалення всіх товарів
        /// </summary>
        public void Clear()
        {
            bookCarts.RemoveAll(x => 1 == 1);
        }

        /// <summary>
        /// Видалення поточного екземпляра кошика
        /// </summary>
        public void RemoveCart()
        {
            cart = null;
        }
        /// <summary>
        /// Is the book in cart?
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool IsSelected(int bookId)
        {
            if (bookCarts.Count > 0)
            {
                foreach (BookCart bookCart in bookCarts)
                {
                    if (bookCart.book.BookId == bookId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public class BookCart
    {
        public decimal sum { get { return amount * book.Price; } }
        public int amount { get; set; }
        public Book book { get; set; }

        public BookCart(Book book)
        {
            this.book = book;
            amount = 1;
        }
        public BookCart(){ }

        /// <summary>
        /// створює екземпляр 'BookCart'
        /// </summary>
        /// <param name="book"></param>
        public void CreateBookCart(Book book)
        {
            this.book = book;
            amount = 1;
        }
    }
    
}