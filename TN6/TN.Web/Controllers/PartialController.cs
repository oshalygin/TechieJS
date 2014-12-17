using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TN.DAL;
using TN.Models;

namespace TN.Web.Controllers
{
    public class PartialController : Controller
    {

        private readonly IBlogRepository _db;

        public PartialController(IBlogRepository db)
        {
            _db = db;
        }



        [ChildActionOnly]
        public ActionResult GetListOfPosts()
        {
            

            //Setup for just 3 posts
            List<Post> posts = _db.RecentPosts();
            @ViewBag.ListOfPosts = posts;


            return View("_ListOfBlogPostsPartial");
        }

        [ChildActionOnly]
        public ActionResult MostCommonTags()
        {
            List<Tag> tags = _db.MostCommonTags();
            @ViewBag.ListOfTags = tags;

            return View("_ListOfMostCommonTagsPartial");
        }
	}
}