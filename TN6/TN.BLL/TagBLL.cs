using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TN.Models;

namespace TN.BLL
{
    public class TagBLL
    {

        public List<Tag> CreateTag(string tagInput)
        {
            List<Tag> tagBuilder = new List<Tag>();
            string[] tagName = tagInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            tagBuilder.AddRange(tagName.Select(x => new Tag() { Name = x }));

            return tagBuilder;
        }
    }
}
