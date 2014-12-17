using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TN.Models.Common;


namespace TN.Models
{
    public class UserDetailsViewModel
    {

        public string FirstName { get; set; }


        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;

            }
        }





        public string State { get; set; }


        public string UserName { get; set; }


        public string Company { get; set; }


        public string PhotoPath { get; set; }


        public string CurrentPosition { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string TwitterId { get; set; }
        public string FacebookId { get; set; }
        public string SkypeId { get; set; }
        public string GooglePlusId { get; set; }

        public DateTime? DateUserDetailsUpdated { get; set; }

        [FileType("jpg,png,gif,bmp")]
        [FileSize(3, ErrorMessage = "Must be less than 3MB")]

        public HttpPostedFileBase File { get; set; }


    }
}
