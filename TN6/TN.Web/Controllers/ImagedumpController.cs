using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN.BLL.Utility;
using TN.DAL;
using TN.Models;

namespace TN.Web.Controllers
{
    public class ImagedumpController : Controller
    {

        private readonly IBlogRepository _db;

        public ImagedumpController(IBlogRepository db)
        {
            _db = db;
        }



        [ChildActionOnly]
        public ActionResult ImageUploadForm()
        {
            return View("_NewImageUpload");
        }


        [HttpGet]
        public ActionResult Index(int? page)
        {
            const int imagesPerPage = 8;
            int pageNumber = page ?? 1;

            var images = _db.ListOfImages(pageNumber, imagesPerPage);

            //var listOfImages = _db.ImageList();

            return View(images);

        }

      

 

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult NewImageUpload(UploadPublicImageViewModel model, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                string photoPath = ImageUtility.UpdatePhoto(file, ImagePath.PublicImage);
                _db.SavePublicImage(model.Description, photoPath);
                
                return RedirectToAction("Index", "Imagedump");

            }

            return View("Index",model);
        }
    }
}