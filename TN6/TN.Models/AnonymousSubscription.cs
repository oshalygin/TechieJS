using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class AnonymousSubscription
    {

        public AnonymousSubscription()
        {
            DateSubscribed = DateTime.Now;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "You can't leave this empty")]
        [EmailAddress(ErrorMessage = "Enter a valid E-mail Address")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public DateTime DateSubscribed { get; private set; }
        public DateTime? UnsubscribedDate { get; private set; }
        public bool Unsubscribed { get; set; }


    }
}
