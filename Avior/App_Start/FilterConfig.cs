using Avior.Base.Interfaces;
using System.Web;
using System.Web.Mvc;

namespace Avior
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
