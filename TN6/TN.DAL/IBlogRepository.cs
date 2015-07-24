using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using TN.Models;

namespace TN.DAL
{
    public interface IBlogRepository
    {
        //Post UpdatePost(int? id, string title, string body, DateTime date, string tags, string file);

        Tag CreateNewTag(string tagName);

        Post GetPost(int? postId);
        IPagedList<Post> ListOfPosts(int pageNumber, int postsPerPage);

        IPagedList<PublicImage> ListOfImages(int imagesPerPage, int page);

        IPagedList<Post> SearchResultList(string searchTerm, int resultsPerPage, int page);

        IPagedList<Post> ListOfInactivePosts(int page, int postsPerPage);
        
        void SaveComment(int id, string name, string commentBody, string emailAddress);

        void SaveSearch(string searchTerm, string operatingSystem, string browser);

        void DeactivatePost(int id);

        bool ValidateDuplicateTitle(string title);

        void RemoveComment(int id);

        Comment GetComment(int id);

        void EditComment(int commentId, string body);

        Tag GetTaggedPosts(string tagName);

        List<Post> RecentPosts();

        List<Tag> MostCommonTags();
        int GetPostId(string urltitle);
        string GetPostTitle(int id);

        void SavePublicImage(string description, string imagePath);

        void SaveEmailTransmission(string name, string email, string body, string website);

    }
}
