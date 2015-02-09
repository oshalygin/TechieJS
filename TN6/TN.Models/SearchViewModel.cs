using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.Models
{
    public class SearchViewModel
    {
        public int Id { get; set; }
        public string SearchTerm { get; set; }

        public string Device { get; set; }

        public DateTime Date { get; set; }
                

    }
}
