using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class UserController : Controller
    {
        private NewUserDBContext db = new NewUserDBContext();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.NewUsers.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            NewUser newuser = db.NewUsers.Find(id);
            if (newuser == null)
            {
                return HttpNotFound();
            }
            return View(newuser);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewUser newuser)
        {
            if (ModelState.IsValid)
            {
                db.NewUsers.Add(newuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newuser);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NewUser newuser = db.NewUsers.Find(id);
            if (newuser == null)
            {
                return HttpNotFound();
            }
            return View(newuser);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewUser newuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newuser);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NewUser newuser = db.NewUsers.Find(id);
            if (newuser == null)
            {
                return HttpNotFound();
            }
            return View(newuser);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewUser newuser = db.NewUsers.Find(id);
            db.NewUsers.Remove(newuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}