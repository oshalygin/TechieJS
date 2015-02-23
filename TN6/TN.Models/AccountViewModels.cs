using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
using TN.Models.Common;


namespace TN.Models
{
    public class UserPropertiesViewModel
    {

        [Required(ErrorMessage = "You can't leave this empty")]
        [Display(Name = "First name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First name must be alpha characters only.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You can't leave this empty")]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Last name must be alpha characters only.")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;

            }
        }

        [Required(ErrorMessage = "You can't leave this empty")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Joined")]
        public DateTime JoinDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        [Required]
        [RegularExpression(@"^[\w{.,'}+:?®©-]+$", ErrorMessage = "No special characters in the username")]
        [MaxLength(12, ErrorMessage = "Username cannot be longer than 12 characters")]
        public string UserName { get; set; }


        public string Company { get; set; }

        public int Age { get; set; }

        public string PhotoPath { get; set; }


        public string CurrentPosition { get; set; }
        public string Description { get; set; }
        public string TwitterId { get; set; }
        public string FacebookId { get; set; }
        public string SkypeId { get; set; }
        public string GooglePlusId { get; set; }

        public DateTime? DateUserDetailsUpdated { get; set; }

        public HttpPostedFileBase File { get; set; }

        

    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "You can't leave this empty")]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long and cannot exceed 12 letters", MinimumLength = 4)]
        [Display(Name = "User name")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The username can only be comprised of letters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You can't leave this empty")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long and cannot exceed 20 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You can't leave this empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The Password and Confirmed Password don't match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You can't leave this empty")]
        [EmailAddress(ErrorMessage = "Enter a valid E-mail Address")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "You can't leave this empty")]
        [EmailAddress(ErrorMessage = "Enter a valid E-mail Address")]
        [Display(Name = "Confirm Email")]
        [System.ComponentModel.DataAnnotations.Compare("EmailAddress", ErrorMessage = "The Email Address and Confirmed Email don't match")]
        public string ConfirmEmail { get; set; }


        [Required(ErrorMessage = "You can't leave this empty")]
        [Display(Name = "First name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First name can only be comprised of letters.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "You can't leave this empty")]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Last name can only be comprised of letters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You can't leave this empty")]
        [StringLength(20)]
        public string Gender { get; set; }


        [Required(ErrorMessage = "You can't leave this empty")]
        public string State { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "You can't leave this empty")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Phone]
        [Required(ErrorMessage = "You can't leave this empty")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }


        [MustBeTrue(ErrorMessage = "You must accept the Terms and Conditions")]
        [DisplayName("I agree to the Terms and Conditions")]
        public bool AcceptsTerms { get; set; }

        [MustBeTrue(ErrorMessage = "You must accept the Privacy Policy")]
        [DisplayName("I agree to the Privacy Policy")]
        public bool AcceptsPrivacyPolicy { get; set; }

    }

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "User name must be alphanumeric only.")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First name must be alpha characters only.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Last name must be alpha characters only.")]
        public string LastName { get; set; }


    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class ExtPropertyViewModel
    {
        public string Issuer { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class RegistrationLists
    {

    }
}
