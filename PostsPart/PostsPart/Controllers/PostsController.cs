using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostsPart.Controllers
{
    public class PostsController : Controller
    {
        //
        // GET: /Posts/

        public ActionResult Index()
        {
            return View();
        }

        //Fetches posts form database

        public ActionResult PostsFetche()
        {
            List<PostTable> listAllPosts = new List<PostTable>();

            //Data Context
            using (PostsDataBaseEntities dbe = new PostsDataBaseEntities())
            {
                listAllPosts = dbe.PostTables.ToList();
            }

            return View(listAllPosts);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(PostTable newPost)
        {
            if (newPost.PostTitle == null)
            {
                ModelState.AddModelError("CustomMessage", "Please enter the title.");
                return View();
            }
            else
            {
                if(newPost.File != null)
                {
                    if (newPost.File.ContentLength > (4*1024*1024))
                    {
                        ModelState.AddModelError("CustomError", "Image can not be lager than 4MB.");
                        return View();
                    }
                    if (!(newPost.File.ContentType == "image/jpeg" || newPost.File.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("CustomError", "Image must be jpeg or gif type.");
                    }
                    newPost.FileName = newPost.File.FileName;
                    newPost.ImageSize = newPost.File.ContentLength;
                    byte[] data = new byte[newPost.File.ContentLength];
                    newPost.File.InputStream.Read(data, 0, newPost.File.ContentLength);
                    newPost.ImageData = data;

                    using (PostsDataBaseEntities dbe = new PostsDataBaseEntities())
                    {
                        dbe.PostTables.Add(newPost);
                        dbe.SaveChanges();
                    }

                }
                if (newPost.TextPost != null)
                {
                    using (PostsDataBaseEntities dbe = new PostsDataBaseEntities())
                    {
                        dbe.PostTables.Add(newPost);
                        dbe.SaveChanges();
                    }
                }
                return RedirectToAction("PostsFetche");
            }
        }
    }
}
