using System;
using System.Web;
using GDNET.Common.Base.Services;
using GDNET.Web.Helpers;
using GDNET.Web.MultilingualControls;
using NHibernate;
using NHibernate.Context;
using WebFrameworkDomain.Common.Repositories;
using WebFrameworkServices;

namespace WebFrameworkNHibernate
{
    /// <summary>
    /// NHibernate session management module
    /// </summary>
    public sealed class NHibernateSessionModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnBeginRequest);
            context.EndRequest += new EventHandler(OnEndRequest);
            context.AuthenticateRequest += new EventHandler(OnAuthenticateRequest);
        }

        #endregion

        #region Events

        /// <summary>
        /// Open a NHibernate session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnBeginRequest(object sender, EventArgs e)
        {
            ISession session = NHibernateHttpApplication.SessionFactory.OpenSession();
            ManagedWebSessionContext.Bind(HttpContext.Current, session);

            // Set data repositories
            if (HttpContextAssistant.TryGetItem<WebRepositories>("DataRepositories") == null)
            {
                HttpContextAssistant.TrySetItem("DataRepositories", new WebRepositories());
            }

            // Set multilingual service
            IRepositoryTranslation repositoryTranslation = HttpContextAssistant.TryGetItem<WebRepositories>("DataRepositories").GetRepositoryTranslation();
            MultilingualServiceHelper.Initialize(new MultilingualService(repositoryTranslation));
        }

        /// <summary>
        /// Release NHibernate session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnEndRequest(object sender, EventArgs e)
        {
            ISession session = ManagedWebSessionContext.Unbind(HttpContext.Current, NHibernateHttpApplication.SessionFactory);
            if (session != null)
            {
                if (session.Transaction.IsActive)
                {
                    session.Transaction.Rollback();
                }

                if (session.IsOpen)
                {
                    session.Flush();
                    session.Close();
                }
            }
        }

        void OnAuthenticateRequest(object sender, EventArgs e)
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
