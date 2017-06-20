using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webNew3.Models;

namespace webNew3.Controllers
{
    [Authorize(Roles="A")]
    public class BookController : Controller
    {
        private BookDbContext db = new BookDbContext();

        // GET: /Book/
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author);
            return View(books.ToList());
        }

        // GET: /Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "LastName");
            return View();
        }

        // POST: /Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include= "BookTitle,AuthorId,Description,Category,Price,BookCover")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.BookCover = book.BookCover.ToLower() == ImageDefaultPath.imageDefaultPath.ToLower() ? 
                    string.Empty : book.BookCover;
                book.InStock = true;
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "LastName", book.Author);
            return View(book);
        }

        // GET: /Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(x => x.Author).FirstOrDefault(x => x.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "LastName", book.Author.AuthorId);
            return View(book);
        }

        // POST: /Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "BookId,BookTitle,AuthorId,Description,Category,Price,BookCover,InStock")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = book.BookId});
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "LastName", book.Author);
            return View(book);
        }

        // GET: /Book/Delete/5
        public ActionResult RemoveFromStock(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("RemoveFromStock")]
        public ActionResult Remove(int id)
        {
            Book book = db.Books.Include(x => x.Author).FirstOrDefault(x => x.BookId == id);
            book.InStock = false;
            book.Author.InStock = false;
            foreach(Book b in book.Author.Books)
            {
                if (b.InStock == true)
                {
                    book.Author.InStock = true;
                }
            }
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddToStock(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("AddToStock")]
        public ActionResult Add(int id)
        {
            Book book = db.Books.Include(x => x.Author).FirstOrDefault(x => x.BookId == id);
            book.InStock = true;
            if (book.Author.InStock == false)
            {
                book.Author.InStock = true;
            }
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
