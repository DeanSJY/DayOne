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
    public class ShareController : Controller
    {
        private ShareService shareService = new ShareService();

        public ActionResult Share()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Query(ShareQuery query)
        {
            if (query == null)
            {
                return Json(false);
            }

            var statement = shareService.QueryShareList(query);

            Func<ShareInfo, ShareableContent> tranform = o =>
            {
                shareService.LoadIsMyPraised(o);

                var result = new ShareableContent(o);

                return result;
            };

            return Json(JsonDataList.CreateTransformResult(statement, tranform, query.Offset, query.Limit > 0 ? query.Limit : 4));
        }


        public JsonResult ToggleLoveIt(int shareId)
        {
            return Json(shareService.ToggleLoveIt(shareId), JsonRequestBehavior.AllowGet);
        }
    }
}