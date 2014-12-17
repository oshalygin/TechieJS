using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TN.Models.Common
{
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public FileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            //Divide by 1000000 to get the value in bytes.
            return _maxSize > ((value as HttpPostedFileBase).ContentLength) / 1048576;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("The file size cannot exceed {0}MB", _maxSize);
        }
    }
}
