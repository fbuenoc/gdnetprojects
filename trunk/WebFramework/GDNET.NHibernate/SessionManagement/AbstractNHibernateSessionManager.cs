using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace GDNET.NHibernate.SessionManagement
{
    public abstract class AbstractNHibernateSessionManager
    {
        protected static ISessionFactory _sessionFactory = null;

        /// <summary>
        /// Must be defined in sub-classes
        /// </summary>
        public static AbstractNHibernateSessionManager Instance
        {
            get { throw new NotImplementedException("Must be implemented in concrete implementation."); }
        }

        public Configuration Configuration
        {
            get;
            protected set;
        }

        public virtual ISession GetSession()
        {
            if (CurrentSessionContext.HasBind(_sessionFactory))
            {
                return CurrentSessionContext.Unbind(_sessionFactory);
            }
            else
            {
                var nhSession = _sessionFactory.OpenSession();
                CurrentSessionContext.Bind(nhSession);

                return nhSession;
            }
        }

        public virtual ITransaction BeginTransaction()
        {
            var nhSession = this.GetSession();
            if (nhSession != null)
            {
                return nhSession.BeginTransaction();
            }

            return null;
        }

        public virtual void CommitTransaction()
        {
            ISession nhSession = this.GetSession();
            if (nhSession != null && nhSession.Transaction != null)
            {
                if (nhSession.Transaction.IsActive && !nhSession.Transaction.WasCommitted)
                {
                    nhSession.Transaction.Commit();
                }

                nhSession.Transaction.Dispose();
            }
        }

        public virtual void RollbackTransaction()
        {
            ISession nhSession = this.GetSession();
            if (nhSession != null && nhSession.Transaction != null)
            {
                if (nhSession.Transaction.IsActive && !nhSession.Transaction.WasRolledBack)
                {
                    nhSession.Transaction.Rollback();
                }
                nhSession.Transaction.Dispose();
            }
        }

        public void CloseSession()
        {
            if (_sessionFactory != null)
            {
                if (CurrentSessionContext.HasBind(_sessionFactory))
                {
                    ISession session = CurrentSessionContext.Unbind(_sessionFactory);
                    if (session.IsOpen)
                    {
                        session.Close();
                    }

                    session.Dispose();
                }
            }
        }
    }
}
