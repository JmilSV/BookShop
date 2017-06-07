using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webNew3.Models;
using PagedList;
using PagedList.Mvc;
using System.Collections;

namespace webNew3.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(int? page, string searchAuthor, string searchBookTitle, string searchBy,
            string QuickSearch, Category category = Category.forSoul)
        {
            List<Book> books;
            BookDbContext bookDbContext = new BookDbContext();
            if (string.IsNullOrEmpty(QuickSearch))
            {
                if (string.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(searchAuthor) && string.IsNullOrEmpty(searchBookTitle))
                {
                    Categories.category = category;
                    books = bookDbContext.Books.Where(x => x.Category == category.ToString())
                        .OrderBy(b => b.Author.LastName).ToList();
                }
                else if (searchBy == "all" || string.IsNullOrEmpty(searchBy))
                {
                    Categories.category = null;
                    books = bookDbContext.Books.Where(x => (x.Author.LastName.StartsWith(searchAuthor.Trim()) || string.IsNullOrEmpty(searchAuthor)) &&
                                       (x.Name.StartsWith(searchBookTitle.Trim()) || string.IsNullOrEmpty(searchBookTitle))).ToList();
                }
                else
                {
                    //Categories.category встановлюємо для того, 
                    //щоб кнопки категорій знали, котра має бути антивною (нажатою)
                    //при пошуку
                    switch (searchBy)
                    {
                        case "forSoul": Categories.category = Category.forSoul; break;
                        case "brainLiterature": Categories.category = Category.brainLiterature; break;
                        case "horrors": Categories.category = Category.horrors; break;
                        case "romance": Categories.category = Category.romance; break;
                        case "detective": Categories.category = Category.detective; break;
                        case "forChildren": Categories.category = Category.forChildren; break;
                    }

                    books = bookDbContext.Books.Where(x => (x.Author.LastName.StartsWith(searchAuthor.Trim()) || string.IsNullOrEmpty(searchAuthor)) &&
                        (x.Name.StartsWith(searchBookTitle.Trim()) || string.IsNullOrEmpty(searchBookTitle)) &&
                        (x.Category == searchBy)).ToList();
                }
            }
            else
            {
                Categories.category = null;
                books = bookDbContext.Books.Where(x => x.Author.LastName.StartsWith(QuickSearch.Trim()) ||
                    x.BookTitle.StartsWith(QuickSearch.Trim()) || x.Author.FirstName.StartsWith(QuickSearch.Trim())).ToList();
            }
            return View(books.ToPagedList(page ?? 1, 3));
        }
	}
}