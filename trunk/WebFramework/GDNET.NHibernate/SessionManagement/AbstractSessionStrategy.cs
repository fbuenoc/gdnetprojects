using GDNET.NHibernate.Repositories;
using NHibernate;

namespace GDNET.NHibernate.SessionManagement
{
    public abstract class AbstractSessionStrategy : ISessionStrategy
    {
        private ISession session;
        protected ITransaction transaction;

        public AbstractSessionStrategy(ISession session)
        {
            this.session = session;
        }

        public ISession Session
        {
            get { return this.session; }
        }

        public void BeginTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
            }

            this.transaction = this.session.BeginTransaction();
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
            this.session.Flush();
        }

        public void Clear()
        {
            this.session.Clear();
        }

        public void FlushAndClear()
        {
            this.Flush();
            this.Clear();
        }
    }
}
