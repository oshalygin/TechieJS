using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TN.Models.Common;

namespace TN.Models
{
    public class UploadPublicImageViewModel
    {
        public string Description { get; set; }

        [FileType("jpg,png,gif,bmp")]
        [FileSize(3, ErrorMessage = "Must be less than 3MB")]
        public HttpPostedFileBase File { get; set; }


    }
}
