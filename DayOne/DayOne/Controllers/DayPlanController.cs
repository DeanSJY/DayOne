using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayOne.App_Start;
using DayOne.Entities;
using DayOne.IoObjects;
using DayOne.Services;


namespace DayOne.Controllers
{
    public class DayPlanController : Controller
    {
        private PlanServices planServices = new PlanServices();

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
            if (ModelState.IsValid)
            {
                return Json(ModelState.GetEnumerator());
            }

            return Json(planServices.CreatePlan(planInput));
        }

        public JsonResult List(int start, int limit, PlanType type)
        {
            var statement = planServices.CreateQuery(type);

            return Json(JsonDataList.CreateResult(statement, start, limit), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}