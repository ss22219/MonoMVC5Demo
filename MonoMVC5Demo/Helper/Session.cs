using MonoMVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonoMVC5Demo.Helper
{
    public static class SessionHelper
    {
        static readonly string userKey = "user";
        public static User User(this ControllerBase controller)
        {
            return (User)controller.ControllerContext.HttpContext.Session[userKey];
        }

        public static void User(this ControllerBase controller, User user)
        {
            controller.ControllerContext.HttpContext.Session[userKey] = user;
        }
    }
}