using System.Web;
using System.Web.Mvc;

namespace TN.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //TODO:  Turn this back on for debugging purposes but comment it out when going public...
            filters.Add(new HandleErrorAttribute());
        }
    }
}
