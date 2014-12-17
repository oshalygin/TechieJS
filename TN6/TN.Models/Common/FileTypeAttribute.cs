using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TN.Models.Common
{
    public class FileTypeAttribute : ValidationAttribute
    {
        private readonly List<string> _types;

        public FileTypeAttribute(string types)
        {
            _types = types.Split(',').ToList();
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            string fileExtension = Path.GetExtension((value as HttpPostedFileBase).FileName);
            string truncatedExtension = fileExtension.Substring(1);
            return _types.Contains(truncatedExtension, StringComparer.OrdinalIgnoreCase);
        }

        public override string FormatErrorMessage(string name)
        {
            return "The file type selected is not valid";
        }
    }
}
