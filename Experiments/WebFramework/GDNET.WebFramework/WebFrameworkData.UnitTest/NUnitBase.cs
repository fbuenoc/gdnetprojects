using System;
using GDNET.Extensions;
using GDNET.NHibernate.SessionManagers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using WebFramework.Domain;
using WebFramework.Mapping.Base;
using Environment = NHibernate.Cfg.Environment;

namespace WebFramework.Data.UnitTest
{
    public abstract class NUnitBase
    {
        private static ISessionFactory _sessionFactory = null;
        private static DomainRepositories _testRepositories = null;
        private static ISession _currentSession = null;
        private static TestSessionService _sessionService = null;
        private static ISessionStrategy _sessionStrategy = null;

        public void Init()
        {
            NUnitBase.BuildSessionFactory();

            if (_sessionStrategy == null)
            {
                _sessionStrategy = new TestSessionStrategy(NUnitBase.GetCurrentSession());
            }
            if (_testRepositories == null)
            {
                _testRepositories = new TestRepositories(_sessionStrategy);
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
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
                _sessionFactory.Dispose();
                _sessionFactory = null;
            }
        }

        /// <summary>
        /// Build NHibernate session factory
        /// </summary>
        private static void BuildSessionFactory()
        {
            var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(INHibernateMapping), typeof(INHibernateMapping).Assembly);
            var mapper = new ModelMapper();
            mapper.AddMappings(listeMappingTypes);

            var cfg = new Configuration()
                     .SetProperty(Environment.ReleaseConnections, "on_close")
                     .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                     .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                     .SetProperty(Environment.ConnectionString, "data source=:memory:");

            cfg.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);

            _sessionFactory = cfg.BuildSessionFactory();
            _currentSession = _sessionFactory.OpenSession();
            _currentSession.BeginTransaction();

            new SchemaExport(cfg).Execute(true, true, false, GetCurrentSession().Connection, Console.Out);

            //var hbmMapping = mapper.CompileMappingForAllExplicitlyAddedEntities().AsString();
            //Debug.WriteLine(hbmMapping);
        }

        public static ISession GetCurrentSession()
        {
            return _currentSession;
        }
    }
}
