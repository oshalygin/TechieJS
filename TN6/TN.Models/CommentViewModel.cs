using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TN.Models
{
    public class CommentViewModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Comment Body Required")]
        [AllowHtml]
        [DisplayName("Message")]
        public string Body { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsAnonymous { get; set; }

    }
}
