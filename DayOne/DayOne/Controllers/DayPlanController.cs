using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayOne.Controllers
{
    public class DayPlanController : Controller
    {
        // GET: DayPlan
        public ActionResult Index()
        {
            return View();
        }
    }
}