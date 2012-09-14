using System;
using System.Web;
using GDNET.Data.Base;
using GDNET.Domain.Repositories;
using NHibernate;

namespace GDNET.FrameworkInfrastructure
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
            WebNHibernateSessionManager.Instance.BeginTransaction();

            var currentUser = DomainRepositories.User.FindByEmail("guest@webframework");
            var sessionContext = new DataSessionContext(currentUser);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            WebNHibernateSessionManager.Instance.CommitTransaction();
            WebNHibernateSessionManager.Instance.CloseSession();
        }
    }
}
