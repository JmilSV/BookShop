using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using webNew3.Models;

namespace webNew3.Controllers
{
    public class UserController : Controller
    {
        private BookDbContext db = new BookDbContext();

        public ActionResult LogIn(string ReturnUrl)

        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult LogIn([Bind(Include = "Email, Password")]User user, string ReturnUrl = "")
        {
            User theuser = db.Users.FirstOrDefault(x => x.Email.ToLower() == user.Email.ToLower() &&
                x.Password.ToLower() == user.Password.ToLower());
            if (theuser != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
            ViewBag.NoUser = "Емейл або пароль не збігаються";
            return View();
        }

        [Authorize(Roles = "A,U")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
        // GET: /User/
        [Authorize(Roles = "A")]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: /User/Details/5
        [Authorize(Roles = "A,U")]
        public ActionResult Details(string email)
        {
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "UserId,FirstName,LastName,Email,Password,ConfirmPassword")] User user)
        {
            user.Role = "U";
            if (ModelState.IsValid)
            {
                if (user.Password != user.ConfirmPassword)
                {
                    user.Password = string.Empty;
                    user.ConfirmPassword = string.Empty;
                    return View(user);
                }

                //if there is user with this password in DB
                if (db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
                {
                    ViewBag.IsUser = "Користувач з таким емейлом вже зареєстрований";
                    //Have you forgotten the password?
                    return View(user);
                }

                user.CreatedDateTime = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                if (User.Identity.Name.ToLower() == AdministraterEmail.AdministratorEmail.ToLower())
                {
                    return RedirectToAction("Index");
                }
                return LogIn(user);
            }

            return View(user);
        }

        public ActionResult Success()
        {
            return View();
        }

        // GET: /User/Edit/5
        [Authorize(Roles="A,U")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "A,U")]
        public ActionResult Edit([Bind(Include = 
            "UserId,FirstName,LastName,UserName,Email,Password,Role,CreatedDateTime,ConfirmPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                //Для запобігання крос-скриптовим атакам, встановлюю роль тут, 
                //незалежно від того, що летить на сервер.
                user.Role = "U";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { email = user.Email});
            }
            return View(user);
        }

        // GET: /User/Delete/5
        [Authorize(Roles="A,U")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="A,U")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);

            db.Users.Remove(user);
            db.SaveChanges();

            //Якщо адміністратор видаляє обліковий запис, сесія не завершується,
            //крім випадку, коли адміністратор видаляє свій обліковий запис
            if (User.Identity.Name.ToLower() == AdministraterEmail.AdministratorEmail.ToLower())
            {
                if (user.Email.ToLower() == AdministraterEmail.AdministratorEmail.ToLower())
                {
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index");
            }
            else
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Create");
            }
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
