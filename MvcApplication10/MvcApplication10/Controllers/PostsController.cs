using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication10.Models;

namespace MvcApplication10.Controllers
{
    public class PostsController : Controller
    {
        private PostsDBContext db = new PostsDBContext();

        //
        // GET: /Posts/

        public ActionResult Index()
        {
            return View(db.PostContents.ToList());
        }

        //
        // GET: /Posts/Details/5

        public ActionResult Details(int id = 0)
        {
            PostContent postcontent = db.PostContents.Find(id);
            if (postcontent == null)
            {
                return HttpNotFound();
            }
            return View(postcontent);
        }

        //
        // GET: /Posts/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Posts/Create

        [HttpPost]
        public ActionResult Create(PostContent postcontent)
        {
            if (ModelState.IsValid)
            {
                db.PostContents.Add(postcontent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postcontent);
        }

        //
        // GET: /Posts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PostContent postcontent = db.PostContents.Find(id);
            if (postcontent == null)
            {
                return HttpNotFound();
            }
            return View(postcontent);
        }

        //
        // POST: /Posts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostContent postcontent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postcontent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postcontent);
        }

        //
        // GET: /Posts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PostContent postcontent = db.PostContents.Find(id);
            if (postcontent == null)
            {
                return HttpNotFound();
            }
            return View(postcontent);
        }

        //
        // POST: /Posts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostContent postcontent = db.PostContents.Find(id);
            db.PostContents.Remove(postcontent);
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