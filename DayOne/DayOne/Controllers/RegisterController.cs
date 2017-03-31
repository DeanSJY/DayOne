using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IoObjects;
using Service;

namespace DayOne.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserService _userService;
        public RegisterController()
        {
            _userService = new UserService();
        }

        [HttpPost]
        public ActionResult Register(UserRegister userRegister)
        {
            if (string.IsNullOrWhiteSpace(userRegister.UserName))
            {
                this.ModelState.AddModelError("error", "Username can not be empty!");
                return View();
            }

            if (string.IsNullOrWhiteSpace(userRegister.PassWord))
            {
                this.ModelState.AddModelError("error", "PassWord can not be empty!");
                return View();
            }

            if (string.IsNullOrWhiteSpace(userRegister.PassWord2))
            {
                this.ModelState.AddModelError("error", "Please enter the password again!");
                return View();
            }

            if (!string.Equals(userRegister.PassWord, userRegister.PassWord2))
            {
                this.ModelState.AddModelError("error", "the password is not match!");
                return View();
            }

            var user = new Entity.UserInfo
            {
                UserName = userRegister.UserName,
                PassWord = userRegister.PassWord
            };
            var entry = _userService.Register(user);
            if(entry == null)
            {
                ModelState.AddModelError("error", "Register Failed!");
            }
            return RedirectToAction("Login","Home");
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
