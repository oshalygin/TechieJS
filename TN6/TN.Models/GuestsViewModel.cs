using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TN.Models
{
    public class GuestListViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            { return (FirstName + " " + LastName); }
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy")]
        [DisplayName("Joined")]
        public DateTime JoinDate { get; set; }

        public ICollection<IdentityUserLogin> Logins { get; set; }

    }
}
