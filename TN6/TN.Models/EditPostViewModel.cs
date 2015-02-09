using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TN.Models.Common;


namespace TN.Models
{
    public class EditPostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateEdited { get; set; }

        public string Body { get; set; }

        public string Preview { get; set; }

        public string PhotoPath { get; set; }


        public IList<Comment> Comments { get; set; }


        [FileType("jpg,png,gif,bmp")]
        [FileSize(3, ErrorMessage = "Must be less than 3MB")]
        public HttpPostedFileBase File { get; set; }




    }
}
