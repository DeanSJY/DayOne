using System;
using System.Web;

namespace DayOne.Services
{
    /// <summary>
    /// ͬ��httpSession����֤��Ϣ����httpContext.User�У���֤Request.IsAuthenticated����������
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