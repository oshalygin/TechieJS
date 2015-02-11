using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.BLL.Utility
{
    public class UserOperatingSystem
    {
        public static string GetUserOs(string userAgent)
        {
            if (userAgent.IndexOf("Windows NT 6.3", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows 8.1";
            }
            if (userAgent.IndexOf("Windows NT 6.2", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows 8";
            }
            if (userAgent.IndexOf("Windows NT 6.1", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows 7";
            }
            if (userAgent.IndexOf("Windows NT 6.0", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows Vista";
            }
            if (userAgent.IndexOf("Windows NT 5.2", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows Server 2003 or Windows XP x64 Edition";
            }
            if (userAgent.IndexOf("Windows NT 5.1", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows XP";
            }
            if (userAgent.IndexOf("Windows NT 5.01", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows 2000, Service Pack 1 (SP1)";
            }
            if (userAgent.IndexOf("Windows NT 5.0", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows 2000";
            }
            if (userAgent.IndexOf("Windows NT 4.0", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Microsoft Windows NT 4.0";
            }
            if (userAgent.IndexOf("Win 9x 4.90", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows Millennium Edition (Windows Me)";
            }
            if (userAgent.IndexOf("Windows 98", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows 98";
            }
            if (userAgent.IndexOf("Windows 95", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows 95";
            }
            if (userAgent.IndexOf("Windows CE", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Windows CE";
            }
            if (userAgent.IndexOf("Intel Mac OS X", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Intel Mac OS X";
            }
            return "Older version of Windows or Mac OS";
        }
    }
}
