using System;
using System.Web;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.Domain;
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
            DataSessionManager.Instance.BeginTransaction();
            ISession currentSession = DataSessionManager.Instance.GetSession();

            var sessionStrategy = new DataSessionStrategy(currentSession);
            var repositories = new DataRepositories(sessionStrategy);

            var currentUser = DomainRepositories.User.FindByEmail("guest@framework");
            var sessionContext = new DataSessionContext(currentUser);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            DataSessionManager.Instance.CommitTransaction();
        }
    }
}
