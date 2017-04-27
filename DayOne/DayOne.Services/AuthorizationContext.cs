using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DayOne.IoObjects;

namespace DayOne.Services
{
    /// <summary>
    /// 用户登录、注销、获取当前登录用户的方法
    /// </summary>
    public static class AuthorizationContext
    {
        private const string SessionKey = "__user_session_key__";

        public static UserPrincipal Login(LoginRequest loginRequest)
        {
            var userInfo = new UserService().Certify(loginRequest.UserName, loginRequest.PassWord);
            if (userInfo == null)
            {
                throw new System.Security.SecurityException("invalid username or password");
            }

            var principal = new UserPrincipal(userInfo);

            var httpContext = HttpContext.Current;
            if (httpContext.Session != null)
            {
                httpContext.Session[SessionKey] = principal;
            }
            httpContext.User = principal;
            return principal;
        }

        public static void Logout()
        {
            var httpContext = HttpContext.Current;
            if (httpContext.Session != null)
            {
                httpContext.Session.Remove(SessionKey);
            }
            httpContext.User = null;
        }

        public static UserPrincipal CurrentPrincipal
        {
            get
            {
                var httpContext = HttpContext.Current;
                if (httpContext.User != null && httpContext.User is UserPrincipal)
                {
                    return (UserPrincipal) httpContext.User;
                }

                if (httpContext.Session != null)
                {
                    var principal = httpContext.Session[SessionKey] as UserPrincipal;
                    if (principal != null)
                    {
                        httpContext.User = principal;
                    }
                    return principal;
                }
                return null;
            }
        }
    }
}
