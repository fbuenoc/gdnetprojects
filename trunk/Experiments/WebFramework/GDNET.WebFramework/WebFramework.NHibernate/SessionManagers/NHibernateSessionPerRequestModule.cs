using System;
using System.Web;
using System.Web.Routing;
using GDNET.NHibernate.SessionManagers;
using GDNET.Web;
using GDNET.Web.Helpers;
using NHibernate;
using NHibernate.Context;
using WebFramework.Services.Common;

namespace WebFramework.NHibernate.SessionManagers
{
    public class LocalhostConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return false;
        }
    }

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

            ManagedWebSessionContext.Bind(HttpContext.Current, session);

            // Set repositories & services
            if (HttpContextAssistant.TryGetItem<FrameworkRepositories>("Repositories") == null)
            {
                ISessionStrategy sessionStrategy = new WebSessionStrategy(session);
                HttpContextAssistant.TrySetItem("Repositories", new FrameworkRepositories(sessionStrategy));
            }
            if (HttpContextAssistant.TryGetItem<InfrastructureServices>("Services") == null)
            {
                HttpContextAssistant.TrySetItem("Services", new InfrastructureServices());
            }

            WebSessionInformationService.Instance.Initialize();
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            ISession session = ManagedWebSessionContext.Unbind(HttpContext.Current, WebStaticSessionManager.Instance.SessionFactory);
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
