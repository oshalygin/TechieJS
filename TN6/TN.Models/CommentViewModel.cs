﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class CommentViewModel
    {
        public int PostId { get; set; }

        [Required]
        [DisplayName("Message")]
        public string Body { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Email Address")]
        public string Email { get; set; }

        public bool IsAnonymous { get; set; }

    }
}
