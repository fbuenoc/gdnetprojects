using System;
using System.Web.Hosting;
using GDNET.Extensions;
using GDNET.NHibernate;
using GDNET.NHibernate.SessionManagers;
using NHibernate;
using NHibernate.Mapping.ByCode;
using WebFrameworkMapping.Base;

namespace GDNET.Web.NHibernate
{
    public class StaticSessionManager : SessionManager
    {
        #region Singleton

        private static class NestedSessionManager
        {
            public static readonly StaticSessionManager SessionManager = new StaticSessionManager();
        }

        public static SessionManager Instance
        {
            get { return NestedSessionManager.SessionManager; }
        }

        #endregion

        #region Fields

        private static readonly string _nhConfigPath = HostingEnvironment.MapPath("~/App_Data/hibernate.cfg.xml");
        private static readonly ISessionFactory _sessionFactory;

        #endregion

        static StaticSessionManager()
        {
            var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(INHibernateMapping), typeof(INHibernateMapping).Assembly);

            var mapper = new ModelMapper();
            mapper.AddMappings(listeMappingTypes);

            try
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = NHibernateAssistant.BuildSessionFactory(_nhConfigPath, mapper);
                }
                else
                {
                    throw new Exception("trying to init SessionFactory twice!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("NHibernate initialization failed", ex);
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

        public override ISession GetCurrentSession()
        {
            return this.SessionFactory.GetCurrentSession();
        }

        #endregion

    }
}
