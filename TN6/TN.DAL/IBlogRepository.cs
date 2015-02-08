using System;
using System.Collections.Generic;
using System.Web;
using PagedList;
using TN.Models;

namespace TN.DAL
{
    public interface IBlogRepository
    {
        Post UpdatePost(int? id, string title, string body, DateTime date, string tags, string file);

        Tag GetTag(string tagName);

        Post GetPost(int? postId);
        IPagedList<Post> ListOfPosts(int pageNumber, int postsPerPage);
        void SaveComment(int id, string name, string commentBody, string emailAddress);

        void RemoveComment(int id);

        Comment GetComment(int id);

        void EditComment(int commentId, string body);

        Tag GetTaggedPosts(string tagName);

        List<Post> RecentPosts();

        List<Tag> MostCommonTags();
        int GetPostId(string urltitle);
        string GetPostTitle(int id);

        void SavePublicImage(string description, string imagePath);

    }
}
