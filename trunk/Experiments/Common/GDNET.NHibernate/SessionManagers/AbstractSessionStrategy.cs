using GDNET.Common.DesignByContract;
using NHibernate;

namespace GDNET.NHibernate.SessionManagers
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
                this.transaction.Dispose();
            }

            this.transaction = this.session.BeginTransaction();
        }

        public void Commit()
        {
            ThrowException.InvalidOperationExceptionIfNull(this.transaction, "You must begin transaction before calling Commit.");

            this.transaction.Commit();
            this.transaction.Dispose();
            this.transaction = null;
        }

        public void Rollback()
        {
            ThrowException.InvalidOperationExceptionIfNull(this.transaction, "You must begin transaction before calling Rollback.");

            this.transaction.Rollback();
            this.transaction.Dispose();

            this.transaction = null;
        }

        public void Flush()
        {
            ThrowException.InvalidOperationExceptionIfNull(this.session, "Session must be valid before synchronizing.");

            this.session.Flush();
        }

        public void Clear()
        {
            ThrowException.InvalidOperationExceptionIfNull(this.session, "Session must be valid before clearing.");

            this.session.Clear();
        }

        public void FlushAndClear()
        {
            this.Flush();
            this.Clear();
        }
    }
}
