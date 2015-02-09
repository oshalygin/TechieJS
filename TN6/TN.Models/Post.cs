using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class Post
    {
        public Post()
        {
            Tags = new HashSet<Tag>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public DateTime Date { get; set; }

        public DateTime DateEdited { get; set; }

        public string Body { get; set; }

        public string Preview { get; set; }

        public string PhotoPath { get; set; }
   

        //Navigational

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
