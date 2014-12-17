using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class SocialMediaReference
    {

        public int Id { get; set; }

        public string TwitterId { get; set; }
        public string FacebookId { get; set; }
        public string SkypeId { get; set; }
        public string GooglePlusId { get; set; }

        public DateTime? TwitterIdLastUpdated { get; set; }
        public DateTime? FacebookIdLastUpdated { get; set; }
        public DateTime? SkypeIdLastUpdated { get; set; }
        public DateTime? GooglePlusIdLastUpdated { get; set; }


        //Navigational

        public int UserId { get; set; }


    }
}
