using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSocialNetworkMyApp.Views;
using SimpleSocialNetworkMyApp.Models;

namespace SimpleSocialNetworkMyApp.Controllers
{
    public class UsersController : Controller
    {
        private UsersDBContext db = new UsersDBContext();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            return RedirectToAction("LogIn");
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            UserRegistration userregistration = db.UserRegistrations.Find(id);
            if (userregistration == null)
            {
                return HttpNotFound();
            }
            return View(userregistration);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRegistration userregistration)
        {
            if (ModelState.IsValid)
            {
                db.UserRegistrations.Add(userregistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userregistration);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserRegistration userregistration = db.UserRegistrations.Find(id);
            if (userregistration == null)
            {
                return HttpNotFound();
            }
            return View(userregistration);
        }

        //
        // POST: /Users/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(UserRegistration userregistration)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(userregistration).State = System.Data.EntityState;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(userregistration);
        //}

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserRegistration userregistration = db.UserRegistrations.Find(id);
            if (userregistration == null)
            {
                return HttpNotFound();
            }
            return View(userregistration);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRegistration userregistration = db.UserRegistrations.Find(id);
            db.UserRegistrations.Remove(userregistration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserRegistration user)
        {
                using (UsersDBContext uc = new UsersDBContext())
                {
                    var v = uc.UserRegistrations.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoggedUserID"] = v.ID.ToString();
                        Session["LoggedUserName"] = v.UserName.ToString();
                        return RedirectToAction("AfterLogIn");
                    }
                }
                return View(user);
            }
           

        public ActionResult AfterLogIn()
        {
            if (Session["LoggedUserID"] != null)
            { 
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}