using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginRequest userInfo)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            //if (string.IsNullOrWhiteSpace(userInfo.UserName)) {
            //    this.ModelState.AddModelError("error", "Username can not be empty!");
            //    return View();
            //}

            //if (string.IsNullOrWhiteSpace(userInfo.PassWord))
            //{
            //    this.ModelState.AddModelError("error", "PassWord can not be empty!");
            //    return View();
            //} 

            var userService = new UserService();
            var result = userService.Certify(userInfo.UserName, userInfo.PassWord);
            if (result != null)
            {
                this.ModelState.AddModelError("error", "PassWord is not match with the Username!");
                return View();
            }
            return RedirectToAction("Index");
        }



    }
}