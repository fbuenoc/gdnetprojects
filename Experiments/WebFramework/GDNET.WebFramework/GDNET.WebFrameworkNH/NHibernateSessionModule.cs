using System;
using System.Web;

using NHibernate;
using NHibernate.Context;

using GDNET.Common.Base;
using GDNET.Common.Base.Services;
using GDNET.Web.Helpers;
using GDNET.Web.MultilingualControls;

using WebFrameworkDomain.Common.Repositories;
using WebFrameworkServices;

namespace WebFrameworkNHibernate
{
    /// <summary>
    /// NHibernate session management module
    /// </summary>
    public sealed class NHibernateSessionModule : IHttpModule
    {
        private IInterceptorService requestInterceptor = null;

        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            this.requestInterceptor = new NHibernateSessionModuleInterceptor();

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
            if (!this.requestInterceptor.IsPassed())
            {
                //return;
            }

            ISession session = NHibernateHttpApplication.SessionFactory.OpenSession();
            ManagedWebSessionContext.Bind(HttpContext.Current, session);

            // Set data repositories
            if (HttpContextHelper.TryGetItem<WebRepositories>("DataRepositories") == null)
            {
                HttpContextHelper.TrySetItem("DataRepositories", new WebRepositories());
            }

            // Set multilingual service
            IRepositoryTranslation repositoryTranslation = HttpContextHelper.TryGetItem<WebRepositories>("DataRepositories").GetRepositoryTranslation();
            MultilingualServiceHelper.Initialize(new MultilingualService(repositoryTranslation));
        }

        /// <summary>
        /// Release NHibernate session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnEndRequest(object sender, EventArgs e)
        {
            if (!this.requestInterceptor.IsPassed())
            {
                //return;
            }

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
            if (!this.requestInterceptor.IsPassed())
            {
                //return;
            }

            // Set web session service
            if (HttpContextHelper.TryGetItem<WebSessionService>("SessionService") == null)
            {
                HttpContextHelper.TrySetItem("SessionService", new WebSessionService());
            }
        }

        #endregion
    }
}
