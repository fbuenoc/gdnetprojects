using GDNET.DataGeneration.Interceptors;
using GDNET.NHibernate.SessionManagement;
using NHibernate;

namespace GDNET.DataGeneration.SessionManagement
{
    public class DataGenerationNHibernateSessionManager : ApplicationNHibernateSessionManager
    {
        #region Singleton

        private class Nested
        {
            public static readonly DataGenerationNHibernateSessionManager instance = new DataGenerationNHibernateSessionManager();
        }

        public new static DataGenerationNHibernateSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        public override void BeginTransaction()
        {
            ISession nhSession = this.ContextSessions[SessionKey] as ISession;
            if (nhSession == null)
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = this.BuildSessionFactory(new DataGenerationModificationInterceptor());
                }
                nhSession = _sessionFactory.OpenSession();
                this.ContextSessions[SessionKey] = nhSession;
            }

            nhSession.BeginTransaction();
        }
    }
}
