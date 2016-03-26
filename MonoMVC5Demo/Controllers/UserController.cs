using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonoMVC5Demo.Helper;
using MonoMVC5Demo.Models;

namespace MonoMVC5Demo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            this.User(null);
            return Redirect("~/");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (string.IsNullOrEmpty(user.user_name) || string.IsNullOrEmpty(user.password))
                ViewBag.Message = "用户名和密码不能为空";
            else
                using (var connection = this.OpenConnection())
                {
                    user = connection.Query<User>("select * from user where user_name=@user_name and password=@password", user).FirstOrDefault();

                    if (user == null)
                        ViewBag.Message = "用户名或密码错误";
                    else
                    {
                        this.User(user);
                        return Redirect("~/Home/Index");
                    }
                }
            return View();
        }


        // GET: User
        [HttpGet]
        public ActionResult Regist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regist(User user)
        {
            if (string.IsNullOrEmpty(user.user_name) || string.IsNullOrEmpty(user.password))
                ViewBag.Message = "用户名和密码不能为空";
            else
                using (var connection = this.OpenConnection())
                {
                    try
                    {
                        var userExists = connection.Query<User>("select * from user where user_name=@user_name", user).FirstOrDefault();
                        if (userExists == null)
                        {
                            connection.Execute("insert into user (user_name,password,email) values (@user_name,@password,@email)", user);
                            return Redirect("~/User/Login");
                        }
                        else
                        {
                            ViewBag.Message = "用户名已经存在";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "注册失败!原因 : " + ex.Message;
                    }
                }
            return View();
        }
    }
}