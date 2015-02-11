using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using PagedList;
using TN.BLL.Utility;
using TN.Models;

namespace TN.DAL
{
    public class BlogRepository : RepositoryBase<TNDbContext>, IBlogRepository
    {
        private readonly bool _localDataOnly = Boolean.Parse(ConfigurationManager.AppSettings["LocalDataOnly"]);
        public Post GetPost(int? postId)
        {
            TNDbContext context = DataContext;

            Post post = context.Posts
                .Include(a => a.Tags)
                .Include(b => b.Comments)
                .FirstOrDefault(x => x.Id == postId);

            if (post == null)
            {
                return new Post
                {
                    Views = 0
                };
            }

            post.Views += 1;
            context.Posts.AddOrUpdate(post);
            context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();

            return post;
        }

        public Tag GetTag(string tagName)
        {
            TNDbContext context = DataContext;

            Tag tag = context.Tags.FirstOrDefault(x => x.Name.ToLower() == tagName.ToLower()) ??
                      new Tag() { Name = tagName, TimesTagWasUsed = 1 };

            return tag;

        }

        public Post UpdatePost(int? id, string title, string body, DateTime date, string tags, string photoPath)
        {
            TNDbContext context = DataContext;

            Post post = GetPost(id);
            post.Title = title;
            post.Body = body;

            post.Preview = string.Concat(body.BlogPreviewTruncate(), "...");

            post.Date = date;
            post.Views = 0;
            post.PhotoPath = photoPath;
            post.DateEdited = DateTime.Now;

            string[] titleNames = title.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var newTitle = new StringBuilder();

            for (int i = 0; i < titleNames.Length; i++)
            {
                newTitle.Append(titleNames[i]);
                if (i != (titleNames.Length - 1))
                {
                    newTitle.Append("-");
                }
            }

            post.UrlTitle = newTitle.ToString();


            post.Tags.Clear();

            string[] tagNames = tags.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tag in tagNames)
            {
                Tag tagToIncrement = context.Tags.FirstOrDefault(x => x.Name == tag);

                if (tagToIncrement != null)
                {
                    tagToIncrement.TimesTagWasUsed += 1;
                    context.Tags.AddOrUpdate(tagToIncrement);
                    context.Entry(tagToIncrement).State = EntityState.Modified;

                }

                var tagToAdd = post.Tags.Count(x => x.Name == tag);
                if (tagToAdd == 0)
                {
                    post.Tags.Add(GetTag(tag));
                }

            }



            if (post.Id == default(int))
            {
                context.Posts.Add(post);
                context.Entry(post).State = EntityState.Added;
            }
            else
            {
                context.Posts.AddOrUpdate(post);
                context.Entry(post).State = EntityState.Modified;
            }
            context.SaveChanges();

            return post;
        }


        public IPagedList<Post> ListOfPosts(int postsPerPage, int page)
        {
            TNDbContext context = DataContext;
            return context.Posts
                .Include(a => a.Tags)
                .Include(b => b.Comments)
                .OrderByDescending(x => x.Date)
                .ToPagedList(postsPerPage, page);
        }

        public List<Post> RecentPosts()
        {
            TNDbContext context = DataContext;
            return context.Posts
                .Include(a => a.Tags)
                .Include(b => b.Comments)
                .OrderByDescending(x => x.Date)
                .Take(3)
                .ToList();

        }

        public List<Tag> MostCommonTags()
        {
            TNDbContext context = DataContext;
            return context.Tags
                .OrderByDescending(x => x.TimesTagWasUsed)
                .Take(10)
                .ToList();
        }


        public void SaveComment(int id, string name, string commentBody, string emailAddress)
        {
            TNDbContext context = DataContext;
            Comment comment = new Comment();
            Post post = GetPost(id);
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

            context.SaveChanges();

        }

        public void RemoveComment(int id)
        {
            TNDbContext context = DataContext;
            Comment comment = GetComment(id);
            context.Comments.Remove(comment);
            context.Entry(comment).State = EntityState.Deleted;

            context.SaveChanges();

        }

        public Comment GetComment(int id)
        {
            TNDbContext context = DataContext;
            return context.Comments.Include(y => y.Post).FirstOrDefault(x => x.Id == id);
        }



        public void EditComment(int commentId, string body)
        {
            TNDbContext context = DataContext;
            Comment comment = GetComment(commentId);
            Post post = GetPost(comment.Post.Id);
            comment.Body = body;
            context.Entry(comment).State = EntityState.Modified;
            context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();

        }


        public Tag GetTaggedPosts(string tagName)
        {
            TNDbContext context = DataContext;
            Tag tag = context.Tags.Include(y => y.Post).FirstOrDefault(x => x.Name == tagName);
            return tag;
        }

        public int GetPostId(string urltitle)
        {
            TNDbContext context = DataContext;
            Post post = context.Posts.FirstOrDefault(x => x.UrlTitle == urltitle);
            return post.Id;

        }

        public string GetPostTitle(int id)
        {
            TNDbContext context = DataContext;
            Post post = context.Posts.FirstOrDefault(x => x.Id == id);
            return post.UrlTitle;

        }




        public void SavePublicImage(string description, string imagePath)
        {
            TNDbContext context = DataContext;
            PublicImage publicIamge = new PublicImage
            {
                ImagePath = imagePath,
                Description = description,
                UploadDate = DateTime.Now
            };

            context.PublicImages.Add(publicIamge);

            context.SaveChanges();

        }


        public IPagedList<PublicImage> ListOfImages(int imagesPerPage, int page)
        {
            TNDbContext context = DataContext;
            return context.PublicImages
                .OrderByDescending(x => x.UploadDate)
                .ToPagedList(imagesPerPage, page);
        }

        public IPagedList<Post> SearchResultList(string searchTerm, int resultsPerPage, int page)
        {


            TNDbContext context = DataContext;
            var query = context.Posts
                .Include(a => a.Tags)
                .Include(b => b.Comments);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
            
                string[] terms = searchTerm.Split(null);


                
                foreach (var term in terms)
                {
                    string search = term;
                    query = query.Where(post => (post.Title.Contains(search) || post.Tags.Any(tag => tag.Name.StartsWith(search))));
                }
            }

            return query
                .OrderByDescending(x => x.Views)
                .ToPagedList(page, resultsPerPage);


        }

        public void SaveSearch(string searchTerm, string operatingSystem, string browser)
        {
            TNDbContext context = DataContext;
            Search newSearch = new Search
            {
                Date = DateTime.Now,
                OperatingSystem = operatingSystem,
                Browser = browser,
                SearchTerm = searchTerm
            };
            context.Searches.Add(newSearch);
            context.Entry(newSearch).State = EntityState.Added;
            context.SaveChanges();

        }





    }
}
