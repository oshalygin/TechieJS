using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class Contact
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Body { get; set; }


    }
}
