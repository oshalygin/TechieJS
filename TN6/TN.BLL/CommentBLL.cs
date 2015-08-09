using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TN.DAL;
using TN.Models;

namespace TN.BLL
{
    public class CommentBLL
    {
        private static readonly CommentBLL instance = new CommentBLL();
        private static readonly BlogRepository _repo = new BlogRepository();

        static CommentBLL()
        {

        }

        private CommentBLL()
        {

        }

        public static CommentBLL Instance
        {
            get { return instance; }
        }


        public bool NewComment(int id, string name, string commentBody, string emailAddress)
        {


            Comment comment = new Comment();
            Post post = _repo.GetPost(id);
            post.Views -= 1;

            comment.Name = name;
            comment.Body = HttpUtility.HtmlEncode(commentBody);
            comment.Email = emailAddress;
            comment.Date = DateTime.Now;

            if (string.IsNullOrEmpty(emailAddress))
            {
                comment.IsAnonymous = true;
            }

            post.Comments.Add(comment);
            int success = _repo.SaveComment(comment, post);

            return success > 0;


        }
    }
}