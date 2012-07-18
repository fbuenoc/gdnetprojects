using System.Collections;
using GDNET.NHibernate.Interceptors;
using NHibernate;
using NHibernate.Cfg;

namespace GDNET.NHibernate.SessionManagement
{
    public abstract class AbstractNHibernateSessionManager
    {
        protected const string ContextSessionsKey = "ContextSessions";
        protected const string SessionKey = "SessionKey";
        protected static ISessionFactory _sessionFactory = null;

        /// <summary>
        /// Must be defined in sub-classes
        /// </summary>
        public static AbstractNHibernateSessionManager Instance
        {
            get { return null; }
        }

        public Configuration Configuration
        {
            get;
            protected set;
        }

        protected abstract Hashtable ContextSessions { get; }
        protected abstract ISessionFactory BuildSessionFactory(params IInterceptor[] interceptors);

        public virtual ISession GetSession()
        {
            return (this.ContextSessions[SessionKey] as ISession);
        }

        public virtual void BeginTransaction()
        {
            ISession nhSession = this.ContextSessions[SessionKey] as ISession;
            if (nhSession == null)
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = this.BuildSessionFactory(new EntityWithModificationInterceptor());
                }
                nhSession = _sessionFactory.OpenSession();
                this.ContextSessions[SessionKey] = nhSession;
            }

            nhSession.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            ISession nhSession = this.ContextSessions[SessionKey] as ISession;
            if (nhSession != null)
            {
                if (nhSession.Transaction != null)
                {
                    nhSession.Transaction.Commit();
                    nhSession.Transaction.Dispose();
                }

                nhSession.Close();
                nhSession.Dispose();

                this.ContextSessions.Remove(SessionKey);
            }
        }

        public virtual void RollbackTransaction()
        {
            ISession nhSession = this.ContextSessions[SessionKey] as ISession;
            if (nhSession != null)
            {
                if (nhSession.Transaction != null)
                {
                    nhSession.Transaction.Rollback();
                    nhSession.Transaction.Dispose();
                }

                nhSession.Close();
                nhSession.Dispose();

                this.ContextSessions.Remove(SessionKey);
            }
        }
    }
}
