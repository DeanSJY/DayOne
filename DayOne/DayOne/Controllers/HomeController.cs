using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using DayOne.Services;
using DayOne.IoObjects;

namespace DayOne.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Login()
        {
            return View("login");
        }
        public ActionResult UserInfo() {
            return View("UserInfo");
        }

        [HttpPost]
        public ActionResult Login(LoginRequest userInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DayOne.Services.AuthorizationContext.Login(userInfo);

                    return RedirectToAction("Index");
                }
                catch (SecurityException e)
                {
                    ModelState.AddModelError("UserName", "账号名或密码错误");
                }
            }

            return View();
        }


        public ActionResult Logout()
        {
            DayOne.Services.AuthorizationContext.Logout();

            return Redirect("/");
        }
    }
}