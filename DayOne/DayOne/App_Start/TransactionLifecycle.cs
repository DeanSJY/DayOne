using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace DayOne.App_Start
{
    public class TransactionLifecycle : System.Web.IHttpModule
    {
        private const string _TRANSACION_SCOPE_KEY = "transaction_pre_request";
        private const string _TRANSACTON_ERROR_KEY = "transaction_error_flag";

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
            context.Error += OnError;
        }

        protected void OnError(object sender, EventArgs e)
        {
            HttpContext.Current.Items[_TRANSACTON_ERROR_KEY] = true;
        }


        void OnBeginRequest(object sender, EventArgs e)
        {
            var scope = HttpContext.Current.Items[_TRANSACION_SCOPE_KEY] as TransactionScope;
            if (scope == null)
            {
                HttpContext.Current.Items[_TRANSACION_SCOPE_KEY] = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted });
            }
        }

        void OnEndRequest(object sender, EventArgs e)
        {
            var scope = HttpContext.Current.Items[_TRANSACION_SCOPE_KEY] as TransactionScope;
            if (scope != null)
            {
                try
                {
                    if (!HttpContext.Current.Items.Contains(_TRANSACTON_ERROR_KEY))
                    {
                        scope.Complete();
                    }

                    DayOne.Entities.DbUtils.DestroyCurrentDB();
                }
                finally
                {
                    scope.Dispose();
                }
            }
        }
    }
}