using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonoMVC5Demo.Helper;

namespace MonoMVC5Demo.Filter
{
    public class MemberFilter : System.Web.Mvc.IActionFilter
    {
        public void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            //Inject User to ViewBag
            filterContext.Controller.ViewBag.User = filterContext.Controller.User();
        }
    }
}