using System.ComponentModel.DataAnnotations;

namespace TN.Models
{
    public class ContactViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Your name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a valid E-mail Address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "That is not a valid E-Mail Address")]
        public string EmailAddress { get; set; }


        [Display(Name = "Message Body")]
        [Required(ErrorMessage = "Message Body is required")]
        public string Body { get; set; }

        [Display(Name = "Website")]
        public string UserWebSite { get; set; }


    }
}
