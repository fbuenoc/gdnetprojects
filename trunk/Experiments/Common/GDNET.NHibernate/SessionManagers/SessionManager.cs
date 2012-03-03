using NHibernate;

namespace GDNET.NHibernate.SessionManagers
{
    public abstract class SessionManager
    {
        #region ISessionManager members

        public abstract ISessionFactory SessionFactory { get; }
        public abstract ISession OpenSession();

        #endregion

        public static SessionManager Instance
        {
            get;
            protected set;
        }
    }
}
