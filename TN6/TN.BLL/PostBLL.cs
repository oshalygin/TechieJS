using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.BLL.Utility;
using TN.DAL;
using TN.Models;

namespace TN.BLL
{
    public class PostBLL
    {

        public Post UpdatePost(int? id, string title, string body, DateTime date, string tags, string photoPath)
        {
            BlogRepository _repo = new BlogRepository();

            Post post = _repo.GetPost(id);

            post.Title = title;
            post.Body = body;

            post.Preview = body.BlogPreviewTruncate();

            post.Date = date;
            post.PhotoPath = photoPath;
            post.DateEdited = DateTime.Now;

            string newTitle = UrlTitleWithDashes(title);
            newTitle = SanitizedUrlTitle(newTitle);

            post.UrlTitle = newTitle;


            post.Tags.Clear();

            //string[] tagNames = tags.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (string tag in tagNames)
            //{
            //    Tag tagToIncrement = context.Tags.FirstOrDefault(x => x.Name == tag);

            //    if (tagToIncrement != null)
            //    {
            //        tagToIncrement.TimesTagWasUsed += 1;
            //        context.Tags.AddOrUpdate(tagToIncrement);
            //        context.Entry(tagToIncrement).State = EntityState.Modified;

            //    }

            //    var tagToAdd = post.Tags.Count(x => x.Name == tag);
            //    if (tagToAdd == 0)
            //    {
            //        post.Tags.Add(GetTag(tag));
            //    }

            //}



            //if (post.Id == default(int))
            //{
            //    context.Posts.Add(post);
            //    context.Entry(post).State = EntityState.Added;
            //}
            //else
            //{
            //    context.Posts.AddOrUpdate(post);
            //    context.Entry(post).State = EntityState.Modified;
            //}
            //context.SaveChanges();

            return post;
        }


      

        public string SanitizedUrlTitle(string preSanitizedTitle)
        {
            string sanitizedTitle = preSanitizedTitle.Trim()
                //Reserved characters
                .Replace("$", "")
                .Replace("&", "")
                .Replace("+", "")
                .Replace(",", "")
                .Replace("/", "")
                .Replace(":", "")
                .Replace(";", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("@", "")
                //Unsafe unsafe
                .Replace("<", "")
                .Replace(">", "")
                .Replace("#", "")
                .Replace("%", "")
                .Replace("{", "")
                .Replace("}", "")
                .Replace("|", "")
                .Replace("\\", "")
                .Replace("^", "")
                .Replace("~", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("`", "")
                //Personal choice
                .Replace("*", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("_", "")
                .Replace(";", "")
                .Replace("!", "")
                .Replace(":", "")
                .Replace("_", "")
                .Replace("'", "");

            return sanitizedTitle;
        }

        public string UrlTitleWithDashes(string preSanitizedUrlTitle)
        {
            string titleWithDashes = preSanitizedUrlTitle.Replace(" ", "-");

            return titleWithDashes;


        }
    }
}
