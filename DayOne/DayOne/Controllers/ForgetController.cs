﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayOne.Services;


namespace DayOne.Controllers
{
    public class ForgetController : Controller
    {
        // GET: Forget
        public ActionResult Forget() {
            ViewBag.Message = "Your contact page.";
            return View("forget");
        }

    }
}