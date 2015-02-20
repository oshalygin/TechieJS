using System.ComponentModel.DataAnnotations;

namespace TN.Models
{
    public class ContactViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a valid E-mail Address")]
        [EmailAddress]
        public string EmailAddress { get; set; }


        [Display(Name = "Message Body")]
        [Required(ErrorMessage = "Email Body is required")]
        public string Body { get; set; }

    }
}
