using System.Web.Hosting;
using GDNET.Common.DesignByContract;
using GDNET.NHibernate;
using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFrameworkNHibernate.SessionManagers
{
    public sealed class WebStaticSessionManager : AbstractSessionManager
    {
        #region Singleton

        private static class NestedSessionManager
        {
            public static readonly WebStaticSessionManager SessionManager = new WebStaticSessionManager();
        }

        public new static SessionManager Instance
        {
            get { return NestedSessionManager.SessionManager; }
        }

        #endregion

        static WebStaticSessionManager()
        {
            if (_sessionFactory == null)
            {
                string nhConfigPath = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
                var mapper = AbstractSessionManager.BuildModelMapper();
                AbstractSessionManager._sessionFactory = NHibernateAssistant.BuildSessionFactory(nhConfigPath, mapper);
            }
            else
            {
                ThrowException.InvalidOperationException("Can't init SessionFactory twice.");
            }

            SessionManager.Instance = NestedSessionManager.SessionManager;
        }

        #region SessionManager members

        public override ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        public override ISession OpenSession()
        {
            return this.SessionFactory.OpenSession();
        }

        #endregion

    }
}
