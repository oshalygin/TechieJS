using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class Comment
    {

        public int Id { get; set; }

        
        public string Body { get; set; }
        public DateTime Date { get; set; }

        
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsAnonymous { get; set; }

        //Navigational



        public Post Post { get; set; }

    }
}
