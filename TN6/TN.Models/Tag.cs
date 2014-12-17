using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class Tag
    {
        public Tag()
        {
            Post = new HashSet<Post>();
        }

        //

        public int Id { get; set; }
        public string Name { get; set; }

        public int TimesTagWasUsed { get; set; }


        //Navigational

        public ICollection<Post> Post { get; set; }


    }
}
