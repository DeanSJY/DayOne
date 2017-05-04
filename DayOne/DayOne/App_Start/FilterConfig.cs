using System.Web;
using System.Web.Mvc;

namespace DayOne
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SecurityFilter());
            filters.Add(new HandleErrorAttribute());
        }

        public class SecurityFilter : System.Web.Mvc.ActionFilterAttribute
        {
            //public override void OnAuthorization(AuthorizationContext filterContext)
            //{

            //    base.OnAuthorization(filterContext);
            //}

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = DayOne.Services.AuthorizationContext.CurrentPrincipal;
                if (user != null)
                {
                    // DO NOTHING
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
