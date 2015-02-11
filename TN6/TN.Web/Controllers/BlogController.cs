using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
using PagedList;
using TN.BLL.Utility;
using TN.DAL;
using TN.Models;

namespace TN.Web.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogRepository _db;

        public BlogController(IBlogRepository db)
        {
            _db = db;
        }




        public ActionResult Index(int? page)
        {
            const int postsPerPage = 5;
            int pageNumber = page ?? 1;

            var posts = _db.ListOfPosts(pageNumber, postsPerPage);

            //bool previousPage = pageNumber > 0;
            //bool nextPage = posts.Count() > postsPerPage;
            //ViewBag.PageNumber = pageNumber;

            return View(posts);
        }

        //TODO: Need multiple search term option

        public ActionResult SearchResults(string searchTerm)
        {
            const int resultsPerPage = 6;
            const int pageNumber = 1;
            if (searchTerm.IsNullOrWhiteSpace())
            {
                searchTerm = "";
            }

            ViewBag.SearchedFor = string.Concat("\"", searchTerm, "\"");
            searchTerm = searchTerm.ToLower();
            var posts = _db.SearchResultList(searchTerm, resultsPerPage, pageNumber);

            string os = UserOperatingSystem.GetUserOs(Request.UserAgent);
            string browser = Request.Browser.Type;

            _db.SaveSearch(searchTerm, os, browser);

            
            return View(posts);
        }





        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Post post = _db.GetPost(id);

            EditPostViewModel model = new EditPostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Date = post.Date,
                Body = post.Body,
                Preview = post.Preview,
                PhotoPath = post.PhotoPath

            };


            StringBuilder tagList = new StringBuilder();
            foreach (Tag tag in post.Tags)
            {
                tagList.AppendFormat("{0}", tag.Name);
            }

            ViewBag.Tags = string.IsNullOrEmpty(tagList.ToString()) ? "" : tagList.ToString();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditPostViewModel model, DateTime date, string tags, HttpPostedFileBase file)
        {



            if (ModelState.IsValid)
            {
                string photoPath = ImageUtility.UpdatePhoto(file, ImagePath.BlogPostImage);

                Post post = _db.UpdatePost(model.Id, model.Title, model.Body, date, tags, photoPath);
                return RedirectToAction("Post", new { UrlTitle = post.UrlTitle });

            }

            //Something went wrong
            model.Date = date;
            model.File = file;
            ViewBag.Tags = tags;
            return View(model);
        }

        //public ActionResult Post(int id)
        //{
        //    Post post = _db.GetPost(id);
        //    return View(post);
        //}

        public ActionResult Post(string UrlTitle)
        {
            int id = _db.GetPostId(UrlTitle);
            Post post = _db.GetPost(id);
            return View(post);
        }

        //Original

        //public ActionResult Comment(int id, string name, string commentBody, string emailAddress)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.SaveComment(id, name, commentBody, emailAddress);
        //    }
        //    return RedirectToAction("Post", "Blog", new { id = id });
        //}





        [HttpGet]
        public ActionResult EditComment(int id)
        {
            Comment model = _db.GetComment(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditComment(int id, string body)
        {
            if (ModelState.IsValid)
            {
                Comment repoComment = _db.GetComment(id);
                _db.EditComment(repoComment.Id, body);
                string postTitle = _db.GetPostTitle(repoComment.Post.Id);
                return RedirectToAction("Post", "Blog", new { UrlTitle = postTitle });
            }
            return View();
        }

        public ActionResult DeleteComment(int id, int postId)
        {
            _db.RemoveComment(id);
            string postTitle = _db.GetPostTitle(postId);

            return RedirectToAction("Post", "Blog", new { UrlTitle = postTitle });
        }

        public ActionResult Tags(string tagName, int? page)
        {
            int returnPage = page ?? 1;

            Tag taggedPosts = _db.GetTaggedPosts(tagName);

            return View("Index", taggedPosts.Post.OrderByDescending(x => x.Date).ToPagedList(returnPage, 15));

        }


        [HttpGet]
        [ChildActionOnly]
        public ActionResult NewComment(int? postId)
        {
            CommentViewModel viewModel = new CommentViewModel();
            if (TempData["CommentModelState"] != null)
            {
                viewModel = (CommentViewModel)TempData["CommentModelState"];
            }
            ViewBag.ViewModel = viewModel;
            ViewBag.postId = postId;
            return View("_PostCommentPartial", viewModel);
        }


        [HttpPost]
        public ActionResult NewComment(CommentViewModel model)
        {

            string postTitle = _db.GetPostTitle(model.PostId);
            if (ModelState.IsValid)
            {
                _db.SaveComment(model.PostId, model.Name, model.Body, model.Email);

                return RedirectToAction("Post", "Blog", new { UrlTitle = postTitle });
            }
            TempData["CommentModelState"] = model;

            //Working on carrying the validation errors over.
            //TempData["CommentValidationErrors"] = ModelState;

            return RedirectToAction("Post", "Blog", new { UrlTitle = postTitle });
        }




    }
}