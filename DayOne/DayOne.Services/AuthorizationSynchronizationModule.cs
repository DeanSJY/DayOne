using System;
using System.Web;

namespace DayOne.Services
{
    /// <summary>
    /// 同步httpSession的认证信息，到httpContext.User中，保证Request.IsAuthenticated运行正常。
    /// </summary>
    public class AuthorizationSynchronizationModule : System.Web.IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        private static void OnBeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.User = AuthorizationContext.CurrentPrincipal;
        }
    }
}