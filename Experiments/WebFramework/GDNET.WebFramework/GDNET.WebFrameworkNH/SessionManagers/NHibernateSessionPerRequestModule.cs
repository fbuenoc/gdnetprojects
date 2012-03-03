using System;
using System.Web;
using GDNET.NHibernate.SessionManagers;
using GDNET.Web;
using GDNET.Web.Helpers;
using NHibernate;
using NHibernate.Context;
using WebFrameworkServices;

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

            // Set repositories & services
            if (HttpContextAssistant.TryGetItem<FrameworkRepositories>("Repositories") == null)
            {
                ISessionStrategy sessionStrategy = new WebSessionStrategy(session);
                HttpContextAssistant.TrySetItem("Repositories", new FrameworkRepositories(sessionStrategy));
            }
            if (HttpContextAssistant.TryGetItem<FrameworkRepositories>("Services") == null)
            {
                HttpContextAssistant.TrySetItem("Services", new InfrastructureServices());
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
