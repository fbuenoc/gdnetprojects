using System;
using System.Web;
using GDNET.NHibernate.SessionManagers;
using GDNET.Web;
using GDNET.Web.Helpers;
using NHibernate;
using NHibernate.Context;

namespace WebFrameworkNHibernate.SessionManagers
{
    public class NHibernateSessionPerRequestModule : IHttpModule
    {
        #region Public Methods

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Application_BeginRequest);
            context.EndRequest += new EventHandler(Application_EndRequest);
            context.AuthenticateRequest += new EventHandler(Application_AuthenticateRequest);
        }

        #endregion

        #region Private Methods

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            ISession session = WebStaticSessionManager.Instance.OpenSession();
            session.BeginTransaction();

            CurrentSessionContext.Bind(session);

            // Set data repositories
            if (HttpContextAssistant.TryGetItem<DataRepositories>("DataRepositories") == null)
            {
                ISessionStrategy sessionStrategy = new WebSessionStrategy(session);
                HttpContextAssistant.TrySetItem("DataRepositories", new DataRepositories(sessionStrategy));
            }
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(WebStaticSessionManager.Instance.SessionFactory);
            if (session != null)
            {
                try
                {
                    session.Transaction.Commit();
                }
                catch (Exception)
                {
                    session.Transaction.Rollback();
                }
                finally
                {
                    session.Close();
                }
            }
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Set web session service
            if (HttpContextAssistant.TryGetItem<WebSessionService>("SessionService") == null)
            {
                HttpContextAssistant.TrySetItem("SessionService", new WebSessionService());
            }
        }

        #endregion

    }
}
