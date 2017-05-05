using System;
using System.Web.Mvc;
using DayOne.IoObjects;
using DayOne.Services;

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
        public ActionResult Index(RegisterRequest userRegister)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var userInfo = _userService.RegisterV1(userRegister);

                Services.AuthorizationContext.Login(new LoginRequest()
                {
                    UserName = userInfo.UserName,
                    PassWord = userRegister.PassWord
                });

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(e.ParamName, e.Message);
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
