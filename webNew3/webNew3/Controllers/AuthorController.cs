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
    [Authorize(Roles = "A")]
    public class AuthorController : Controller
    {
        private BookDbContext db = new BookDbContext();

        // GET: /Author/
        public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }

        // GET: /Author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorId == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: /Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Author/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FirstName,LastName,MiddleName")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.InStock = true;
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: /Author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorId == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: /Author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AuthorId,FirstName,LastName,MiddleName,InStock")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: /Author/Delete/5
        public ActionResult RemoveFromStock(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorId == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: /Author/Delete/5
        [HttpPost, ActionName("RemoveFromStock")]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            Author author = db.Authors.Find(id);
            foreach (var book in author.Books)
            {
                book.InStock = false;
                db.Entry(book).State = EntityState.Modified;
            }
            author.InStock = false;

            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddToStock(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Include(x => x.Books).FirstOrDefault(x => x.AuthorId == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        [HttpPost]
        public ActionResult AddToStock(int id, string withBooks)
        {
            Author author = db.Authors.Find(id);
            author.InStock = true;
            if (!string.IsNullOrEmpty(withBooks))
            {
                foreach (Book book in author.Books)
                {
                    book.InStock = true;
                }
            }
            db.Entry(author).State = EntityState.Modified;
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
