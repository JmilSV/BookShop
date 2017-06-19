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
        public ActionResult Index(int? page, string searchAuthor, string searchBookTitle, 
            string searchBy, string sortBy, Category category = Category.forSoul)
        {
            ViewBag.SortLastNameParameter = string.IsNullOrEmpty(sortBy) ? "lastName desc" : "";
            ViewBag.SortTitleParameter = sortBy == "title" ? "title desc" : "title";

            BookDbContext bookDbContext = new BookDbContext();
            var books = bookDbContext.Books.AsQueryable();

                if (string.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(searchAuthor) && 
                    string.IsNullOrEmpty(searchBookTitle))
                {
                    Categories.category = category;
                    books = books.Where(x => x.Category.ToLower() == 
                        category.ToString().ToLower() && x.InStock == true);
                }
                else if (searchBy == "all" || string.IsNullOrEmpty(searchBy))
                {
                    Categories.category = null;
                    books = books.Where(x => (x.Author.LastName.StartsWith(searchAuthor.Trim().ToLower()) || 
                                       string.IsNullOrEmpty(searchAuthor)) &&
                                       (x.BookTitle.StartsWith(searchBookTitle.Trim().ToLower()) ||
                                       string.IsNullOrEmpty(searchBookTitle)) && x.InStock == true);
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

                    books = books.Where(x => (x.Author.LastName.StartsWith(searchAuthor.Trim().ToLower()) || 
                                        string.IsNullOrEmpty(searchAuthor)) && 
                                        (x.BookTitle.StartsWith(searchBookTitle.Trim().ToLower()) || 
                                        string.IsNullOrEmpty(searchBookTitle)) &&
                                        (x.Category.ToLower() == searchBy.ToLower()) && x.InStock == true);
                }

            //сортування
            switch (sortBy) 
            {
                case "lastName desc": books = books.OrderByDescending(x => x.Author.LastName); break;
                case "title": books = books.OrderBy(x => x.BookTitle); break;
                case "title desc": books = books.OrderByDescending(x => x.BookTitle); break;
                default: books = books.OrderBy(x => x.Author.LastName); break;
            }

            return View(books.ToPagedList(page ?? 1, 10));
        }
	}
}