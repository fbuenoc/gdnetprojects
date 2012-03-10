using System;
using System.Web;
using GDNET.NHibernate.SessionManagers;
using NHibernate;
using NHibernate.Context;

namespace WebFramework.NHibernate.SessionManagers
{
    public class NHibernateSessionPerConversationModule : IHttpModule
    {
        #region Constants

        private const string NHIBERNATE_CONVERSATION_END_FLAG_KEY = "hibernate.conversation.end.flag";
        private const string NHIBERNATE_CURRENT_SESSION_KEY = "hibernate.session";

        #endregion

        #region Public Methods

        public void Dispose()
        {
        }

        public static void SetEndConversationFlag()
        {
            HttpContext.Current.Items[NHIBERNATE_CONVERSATION_END_FLAG_KEY] = true;
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(Application_BeginRequest);
            context.PostRequestHandlerExecute += new EventHandler(Application_EndRequest);
        }

        #endregion

        #region Private Methods

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            ISession currentSession = (ISession)HttpContext.Current.Session[NHIBERNATE_CURRENT_SESSION_KEY];
            if (currentSession == null)
            {
                currentSession = SessionManager.Instance.OpenSession();
                currentSession.FlushMode = FlushMode.Never;
            }
            currentSession.BeginTransaction();

            CurrentSessionContext.Bind(currentSession);
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(SessionManager.Instance.SessionFactory);

            if (HttpContext.Current.Items[NHIBERNATE_CONVERSATION_END_FLAG_KEY] != null)
            {
                session.Flush();
                session.Transaction.Commit();
                session.Close();
                HttpContext.Current.Session[NHIBERNATE_CURRENT_SESSION_KEY] = null;
            }
            else
            {
                session.Transaction.Commit();
                HttpContext.Current.Session[NHIBERNATE_CURRENT_SESSION_KEY] = session;
            }

        }

        #endregion

    }
}