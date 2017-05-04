using DayOne.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayOne.Controllers
{
    public class SetupController : Controller
    {
        // GET: Setup
        public ActionResult Index()
        {
            return View();
        }

        public void UpgradeDB()
        {
            DbUtils.CurrentDB.Database.Initialize(true);
        }
    }
}