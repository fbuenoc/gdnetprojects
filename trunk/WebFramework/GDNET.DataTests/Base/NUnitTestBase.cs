using GDNET.Data;
using GDNET.Data.Base;
using GDNET.Data.Base.Management;
using GDNET.Domain;
using GDNET.Domain.System;
using GDNET.NHibernate.Interceptors;
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
        private ISessionFactory sessionFactory = null;
        private ISession currentSession = null;
        private ISessionStrategy sessionStrategy = null;
        private ITransaction currentTransaction = null;

        protected User CurrentUser
        {
            get;
            private set;
        }

        [SetUp]
        public void SetUp()
        {
            this.BuildSessionFactory();

            this.currentTransaction = currentSession.BeginTransaction();
            this.sessionStrategy = new UnitTestSessionStrategy(currentSession);
            var repositories = new DataRepositories(sessionStrategy);

            this.CurrentUser = User.Factory.Create("test@mail.com", "123456");
            var sessionContext = new DataSessionContext(this.CurrentUser);
            DomainRepositories.User.Save(this.CurrentUser);
        }

        [TearDown]
        public void TearDown()
        {
            if (this.currentTransaction != null && this.currentTransaction.IsActive)
            {
                this.currentTransaction.Rollback();
                this.currentTransaction.Dispose();
            }

            if (this.currentSession != null && this.currentSession.IsOpen)
            {
                this.currentSession.Close();
                this.currentSession.Dispose();
            }

            if (this.sessionFactory != null && !this.sessionFactory.IsClosed)
            {
                this.sessionFactory.Close();
                this.sessionFactory.Dispose();
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
            cfg.SetInterceptor(new EntityWithModificationInterceptor());

            this.sessionFactory = cfg.BuildSessionFactory();
            this.currentSession = sessionFactory.OpenSession();

            (new SchemaExport(cfg)).Execute(true, true, false, currentSession.Connection, Console.Out);
        }
    }
}
