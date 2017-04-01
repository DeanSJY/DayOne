using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayOne.Controllers
{
    public class NoteBookController : Controller
    {
        // GET: NoteBook
        public ActionResult Index()
        {
            return View();
        }
    }
}