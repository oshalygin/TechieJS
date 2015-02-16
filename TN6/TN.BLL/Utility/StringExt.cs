using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.BLL.Utility
{
    public static class StringExt
    {

        private const int _MAXPREVIEWLENGTH = 600;
        private const int _MAXSEARCHLENGTH = 400;
        public static string BlogPreviewTruncate(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            return value.Length <= _MAXPREVIEWLENGTH ? value : value.Substring(0, _MAXPREVIEWLENGTH);
        }

        public static string SearchPreviewLength(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            return value.Length <= _MAXSEARCHLENGTH ? value : value.Substring(0, _MAXSEARCHLENGTH);
        }
    }
}
