﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayOne.Entities;

namespace DayOne.Controllers
{
    public class DayPlanController : Controller
    {
        public ActionResult DayPlan()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        // GET: DayPlan
    } 
}