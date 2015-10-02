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
            TagBLL tagBLL = new TagBLL();


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
            post.Tags = tagBLL.CreateTag(tags);

            List<string> tagList = post.Tags.Select(x => x.Name).ToList();


            if (tagList.Count != 0)
            {
                if (post.Views == 0)
                {
                    int tagSuccess = _repo.IncrementTags(tagList);
                }
               

            }

            if (post.Views > 0)
            {
                //Stupid logic, should have a different method for UpdatePost and NewPost...ugh.
                post.Views--;
            }

            bool success = _repo.SavePost(post);

            return success ? post : null;

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
                .Replace(".", "")
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
