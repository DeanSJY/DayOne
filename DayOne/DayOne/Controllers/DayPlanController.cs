using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayOne.Entities;
using DayOne.IoObjects;
using DayOne.Services;


namespace DayOne.Controllers
{
    public class DayPlanController : Controller
    {
        public ActionResult Index()
        {
            return View("dayplan");
        }

        #region HTML
        public ActionResult AddPlanHTML()
        {
            return View("addplanhtml");
        }

        public ActionResult PlanHTML()
        {
            return View("plan");
        }
        #endregion


        #region API
        public JsonResult AddPlan(PlanInput planInput)
        {
            var plan = new PlanInput();
           
            return null;
        }
        #endregion
    }
}