using NHibernate;

namespace GDNET.NHibernate.SessionManagement
{
    public abstract class AbstractSessionStrategy : ISessionStrategy
    {
        private INHibernateSessionManager sessionManager;
        protected ITransaction transaction;

        public AbstractSessionStrategy(INHibernateSessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public ISession Session
        {
            get { return this.sessionManager.GetSession(); }
        }

        public void BeginTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
            }

            this.transaction = this.sessionManager.GetSession().BeginTransaction();
        }

        public void Commit()
        {
            this.transaction.Commit();
            this.transaction.Dispose();
        }

        public void Rollback()
        {
            this.transaction.Rollback();
            this.transaction.Dispose();
        }

        public void Flush()
        {
            this.sessionManager.GetSession().Flush();
        }

        public void Clear()
        {
            this.sessionManager.GetSession().Clear();
        }

        public void FlushAndClear()
        {
            this.Flush();
            this.Clear();
        }
    }
}
