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



        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }

        //TODO: FIX THE DATABINDING

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult NewImageUpload(UploadPublicImageViewModel model, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                string photoPath = ImageUtility.UpdatePhoto(file, ImagePath.ProfileImage);
                _db.SavePublicImage(model.Description, photoPath);
                
                return RedirectToAction("Index", "Imagedump");

            }

            return View("Index",model);
        }
    }
}