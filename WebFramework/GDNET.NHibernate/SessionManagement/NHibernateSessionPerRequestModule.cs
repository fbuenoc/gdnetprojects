using System;
using System.Web;
using GDNET.Data.Base;

namespace GDNET.NHibernate.SessionManagement
{
    public class NHibernateSessionPerRequestModule : IHttpModule
    {
        private const string ContextSessionsKey = "ContextSessions";
        private const string SessionKey = "SessionKey";

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            DataSessionManager.Instance.BeginTransaction();
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            DataSessionManager.Instance.CommitTransaction();
        }
    }
}
