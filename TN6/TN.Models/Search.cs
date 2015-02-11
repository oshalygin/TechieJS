using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class Search
    {
        public int Id { get; set; }
        public string SearchTerm { get; set; }

        public string Browser { get; set; }
        public string OperatingSystem { get; set; }

        public DateTime Date { get; set; }



    }
}
