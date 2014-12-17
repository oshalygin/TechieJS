using System;

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Identity.EntityFramework;

namespace TN.Models
{
    public class CustomUser : IdentityUser
    {
        public CustomUser()
            : base()
        {
            JoinDate = DateTime.Now;
        }

        public CustomUser(string username)
            : base(username)
        {
            JoinDate = DateTime.Now;
        }

        public DateTime JoinDate { get; private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date Of Birth")]


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string State { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        //Changed from Email to EmailAddress to no longer hide the base property.


        [Phone]
        public string Phone { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }



        public int Age { get; set; }

        public string PhotoPath { get; set; }

        public bool AcceptsTerms { get; set; }
        public bool AcceptsPrivacyPolicy { get; set; }

        public string Description { get; set; }

        public DateTime? DateUserDetailsUpdated { get; set; }



    }
}
