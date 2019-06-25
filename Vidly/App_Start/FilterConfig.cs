using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // Redirects to error page when throwing exception
            filters.Add(new AuthorizeAttribute()); // Require authorization globally
        }
    }
}
