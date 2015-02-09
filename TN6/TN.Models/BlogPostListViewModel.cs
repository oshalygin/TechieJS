using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class BlogPostListViewModel
    {
        public DateTime Date { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        public string Body { get; set; }

        public string Title { get; set; }

        public int Views { get; set; }



    }
}
