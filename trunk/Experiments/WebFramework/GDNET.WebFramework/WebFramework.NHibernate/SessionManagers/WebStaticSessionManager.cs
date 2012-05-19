using System.Web.Hosting;
using GDNET.Common.DesignByContract;
using GDNET.NHibernate;
using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFramework.NHibernate.SessionManagers
{
    public sealed class WebStaticSessionManager : AbstractSessionManager
    {
        private const string HibernateConfiguration = "~/App_Data/hibernate.cfg.xml";
        private const string MappingAssemblies = "~/App_Data/MappingAssemblies.txt";

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
            if (AbstractSessionManager.TheSessionFactory == null)
            {
                var mapper = AbstractSessionManager.BuildModelMapper(HostingEnvironment.MapPath(MappingAssemblies));
                AbstractSessionManager.TheSessionFactory = NHibernateAssistant.BuildSessionFactory(HostingEnvironment.MapPath(HibernateConfiguration), mapper);
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
            get { return AbstractSessionManager.TheSessionFactory; }
        }

        public override ISession OpenSession()
        {
            return this.SessionFactory.OpenSession();
        }

        #endregion

    }
}
