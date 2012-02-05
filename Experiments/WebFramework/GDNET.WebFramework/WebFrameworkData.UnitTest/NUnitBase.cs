using System.Diagnostics;
using GDNET.Extensions;
using GDNET.NHibernate;
using NHibernate;
using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.DefaultImpl;
using WebFrameworkMapping.Base;

namespace WebFrameworkData.UnitTest
{
    public abstract class NUnitBase
    {
        private static ISessionFactory _sessionFactory = null;
        private static DomainRepositories _testRepositories = null;
        private static ISession _currentSession = null;
        private static TestSessionService _sessionService = null;

        public void Init()
        {
            NUnitBase.BuildSessionFactory();

            if (_testRepositories == null)
            {
                _testRepositories = new TestRepositories();
            }
            if (_sessionService == null)
            {
                _sessionService = new TestSessionService();
            }
        }

        /// <summary>
        /// Need to delete all data
        /// </summary>
        public void Clean()
        {
            if (_currentSession != null)
            {
                using (_currentSession)
                {
                    _currentSession.Close();
                }
                _currentSession = null;
            }

            if (_sessionFactory != null)
            {
                using (_sessionFactory)
                {
                    _sessionFactory.Close();
                }
                _sessionFactory = null;
            }
        }

        /// <summary>
        /// Build NHibernate session factory
        /// </summary>
        private static void BuildSessionFactory()
        {
            if (_sessionFactory != null)
            {
                return;
            }

            var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(INHibernateMapping), typeof(INHibernateMapping).Assembly);
            var mapper = new ModelMapper();
            mapper.AddMappings(listeMappingTypes);

            var nhConfigPath = "App_Data/hibernate.cfg.xml";
            _sessionFactory = NHibernateAssistant.BuildSessionFactory(nhConfigPath, mapper);

            var hbmMapping = mapper.CompileMappingForAllExplicitlyAddedEntities().AsString();
            Debug.WriteLine(hbmMapping);

            _sessionFactory = NHibernateAssistant.BuildSessionFactory(nhConfigPath, mapper);
        }

        public static ISession GetCurrentSession()
        {
            if (_currentSession == null || !_currentSession.IsOpen)
            {
                _currentSession = _sessionFactory.OpenSession();
            }
            return _currentSession;
        }
    }
}
