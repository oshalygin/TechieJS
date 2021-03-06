﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using PagedList;
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

        public Tag CreateNewTag(string tagName)
        {
            TNDbContext context = DataContext;

            Tag tag = context.Tags.FirstOrDefault(x => x.Name.ToLower() == tagName.ToLower()) ??
                      new Tag() { Name = tagName, TimesTagWasUsed = 1 };

            return tag;

        }

        public bool ValidateDuplicateTitle(string title)
        {
            TNDbContext context = DataContext;
            var post = context.Posts.FirstOrDefault(x => x.Title == title);
            if (post == null)
            {
                return true;
            }
            return false;
        }

        public int IncrementTags(List<string> tagList)
        {
            TNDbContext context = DataContext;
            
            
                foreach (string t in tagList)
                {
                    Tag tagToIncrement = context.Tags.FirstOrDefault(x => x.Name == t);

                    if (tagToIncrement != null)
                    {
                        tagToIncrement.TimesTagWasUsed += 1;
                        context.Tags.AddOrUpdate(tagToIncrement);
                        context.Entry(tagToIncrement).State = EntityState.Modified;
                    }
                  
                    
                }
            
            return context.SaveChanges();
        }



        public bool SavePost(Post post)
        {
            TNDbContext context = DataContext;

            
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

            return true;
        }


        public IPagedList<Post> ListOfPosts(int postsPerPage, int page)
        {
            TNDbContext context = DataContext;
            return context.Posts
                .Include(a => a.Tags)
                .Include(b => b.Comments)
                .Where(z => z.Inactive == false)
                .OrderByDescending(x => x.Date)
                .ToPagedList(postsPerPage, page);
        }

        public List<Post> RecentPosts()
        {
            TNDbContext context = DataContext;
            return context.Posts
                .Include(a => a.Tags)
                .Include(b => b.Comments)
                .Where(z => z.Inactive == false)
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


        public int SaveComment(Comment newComment, Post existingPost)
        {
            TNDbContext context = DataContext;
            //Comment comment = new Comment();
            //Post post = GetPost(id);
            //post.Views -= 1;

            //comment.Name = name;
            //comment.Body = HttpUtility.HtmlEncode(commentBody);
            //comment.Email = emailAddress;
            //comment.Date = DateTime.Now;

            //if (string.IsNullOrEmpty(emailAddress))
            //{
            //    comment.IsAnonymous = true;
            //}

            existingPost.Comments.Add(newComment);

            context.Entry(newComment).State = EntityState.Added;
            context.Entry(existingPost).State = EntityState.Modified;

            return context.SaveChanges();

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
                .Include(b => b.Comments)
                .Where(z => z.Inactive == false);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string cleanedTerm = searchTerm.Replace(",", " ");

                string[] terms = cleanedTerm.Split(null);



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

        public void DeactivatePost(int id)
        {
            TNDbContext context = DataContext;
            Post post = GetPost(id);
            post.Inactive = true;

            context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();

        }

        public IPagedList<Post> ListOfInactivePosts(int page, int postsPerPage)
        {
            TNDbContext context = DataContext;

            return context.Posts
                .Include(a => a.Tags)
                .Include(b => b.Comments)
                .Where(c => c.Inactive == true)
                .OrderByDescending(d => d.Date)
                .ToPagedList(page, postsPerPage);
        }

        public void SaveEmailTransmission(string name, string email, string body, string website)
        {
            TNDbContext context = DataContext;

            Contact contact = new Contact
            {
                Name = name,
                EmailAddress = email,
                Body = body,
                UserWebSite = website

            };

            context.Entry(contact).State = EntityState.Added;
            context.SaveChanges();

        }



    }
}
