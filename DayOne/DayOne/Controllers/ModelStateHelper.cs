using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayOne.Controllers
{
    public static class ModelStateHelper
    {
        public static List<string> toJson(this System.Web.Mvc.ModelStateDictionary models)
        {
            var errorList = (from item in models
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();
            return errorList;

        }
    }
}