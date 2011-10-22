using System;
using System.Web;

using NHibernate;
using NHibernate.Context;

using GDNET.Common.Base;

namespace GDNET.WebFrameworkNH
{
    /// <summary>
    /// NHibernate session management module
    /// </summary>
    public sealed class NHibernateSessionModule : IHttpModule
    {
        private ISimpleInterceptor requestInterceptor = null;

        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            this.requestInterceptor = new NHibernateSessionModuleInterceptor();

            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //context.LogRequest += new EventHandler(OnLogRequest);
            context.BeginRequest += new EventHandler(OnBeginRequest);
            context.EndRequest += new EventHandler(OnEndRequest);
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
                return;
            }

            ManagedWebSessionContext.Bind(HttpContext.Current, NHibernateHttpApplication.SessionFactory.OpenSession());
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
                return;
            }

            ISession session = ManagedWebSessionContext.Unbind(HttpContext.Current, NHibernateHttpApplication.SessionFactory);

            if (session.Transaction.IsActive)
            {
                session.Transaction.Rollback();
            }

            if (session != null)
            {
                session.Close();
            }
        }

        /// <summary>
        /// Custom logging logic can go here
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        void OnLogRequest(Object source, EventArgs e)
        {
        }

        #endregion
    }
}
