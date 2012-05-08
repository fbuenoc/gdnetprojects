﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GDNET.NHibernate.SessionManagers;
using GDNET.Web;
using GDNET.Web.Helpers;
using NHibernate;
using NHibernate.Context;
using WebFramework.Common.Widgets;
using WebFramework.Domain;
using WebFramework.Services.Common;

namespace WebFramework.NHibernate.SessionManagers
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

            if (ViewEngines.Engines.Count == 0)
            {
                AreaRegistration.RegisterAllAreas();

                var routes = RouteTable.Routes;
                // Route for all widgets
                foreach (var widget in DomainRepositories.Widget.GetAll())
                {
                    string routeName = string.Format("Widget_{0}", widget.TechnicalName);
                    string urlFormat = string.Format("Widget/{0}/{{controller}}/{{action}}/{{id}}", widget.TechnicalName);
                    var namespaces = widget.Properties.Where(x => x.Code == WidgetBaseConstants.ControllerNamespace).Select(x => x.Value).ToArray();
                    if (namespaces.Length > 0)
                    {
                        object defaults = new { controller = "AdminHome", action = "Index", id = UrlParameter.Optional };
                        routes.MapRoute(routeName, urlFormat, defaults, namespaces);
                    }
                }

                routes.MapRoute(
                    "Default",                      // Route name
                    "{controller}/{action}/{id}",   // URL with parameters
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                    new string[] { "WebFramework.Common.Controllers.Main" }
                );

                ViewEngines.Engines.Add(new WebFrameworkViewEngine());
            }
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
