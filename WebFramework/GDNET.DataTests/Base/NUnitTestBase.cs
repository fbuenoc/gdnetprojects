using GDNET.Data;
using GDNET.Data.Base.Management;
using GDNET.NHibernate.Mapping;
using GDNET.NHibernate.Repositories;
using GDNET.Utils;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Console = System.Console;

namespace GDNET.DataTests.Base
{
    public class NUnitTestBase
    {
        private ISessionFactory _sessionFactory = null;
        private ISession _currentSession = null;
        private ISessionStrategy _sessionStrategy = null;
        private ITransaction currentTransaction = null;

        [SetUp]
        public void SetUp()
        {
            this.BuildSessionFactory();

            currentTransaction = _currentSession.BeginTransaction();
            _sessionStrategy = new UnitTestSessionStrategy(_currentSession);
            var repositories = new DataRepositories(_sessionStrategy);
        }

        [TearDown]
        public void TearDown()
        {
            if (currentTransaction != null && currentTransaction.IsActive)
            {
                currentTransaction.Rollback();
                currentTransaction.Dispose();
            }

            if (_currentSession != null && _currentSession.IsOpen)
            {
                _currentSession.Close();
                _currentSession.Dispose();
            }

            if (_sessionFactory != null && !_sessionFactory.IsClosed)
            {
                _sessionFactory.Close();
                _sessionFactory.Dispose();
            }
        }

        /// <summary>
        /// Build NHibernate session factory
        /// </summary>
        private void BuildSessionFactory()
        {
            var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(IEntityMapping), typeof(EntityHistoryMapping).Assembly);
            var mapper = new ModelMapper();
            mapper.AddMappings(listeMappingTypes);

            var cfg = new Configuration()
                     .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                     .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                     .SetProperty(Environment.ConnectionString, "Data Source=test.db");

            cfg.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);

            _sessionFactory = cfg.BuildSessionFactory();
            _currentSession = _sessionFactory.OpenSession();

            (new SchemaExport(cfg)).Execute(true, true, false, _currentSession.Connection, Console.Out);
        }
    }
}
