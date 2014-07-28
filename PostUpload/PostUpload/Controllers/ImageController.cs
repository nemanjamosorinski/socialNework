using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostUpload.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImageFetching()
        {
            List<ImageTable> listAll = new List<ImageTable>();

            using (PostsDataBaseEntities dc = new PostsDataBaseEntities())
            {
                listAll = dc.ImageTables.ToList();
            }
            return View(listAll);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(ImageTable IT)
        {

            if (IT.File.ContentLength > (4 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 4MB");
                return View(IT);
            }
            if (!(IT.File.ContentType == "image/jpeg" || IT.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed: jpeg and gif");
            }

            IT.FileName = IT.File.FileName;
            IT.ImageSize = IT.File.ContentLength;
            byte[] data = new byte[IT.File.ContentLength];
            IT.File.InputStream.Read(data, 0, IT.File.ContentLength);

            IT.ImageData = data;

            using (PostsDataBaseEntities dc = new PostsDataBaseEntities())
            {
                dc.ImageTables.Add(IT);
                dc.SaveChanges();
            }
            return RedirectToAction("ImageFetching");
        }

    }
}
