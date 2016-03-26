using MonoMVC5Demo.Filter;
using System.Web;
using System.Web.Mvc;

namespace MonoMVC5Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MemberFilter());
        }
    }
}
