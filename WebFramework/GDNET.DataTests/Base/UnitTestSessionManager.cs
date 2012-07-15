using System.Collections;
using System.Runtime.Remoting.Messaging;
using GDNET.Mapping.System.Management;
using GDNET.NHibernate.Mapping;
using GDNET.NHibernate.SessionManagement;
using GDNET.Utils;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace GDNET.DataTests.Base
{
    public class UnitTestSessionManager : AbstractSessionManager
    {
        #region Singleton

        private UnitTestSessionManager() { }

        private class Nested
        {
            public static readonly UnitTestSessionManager instance = new UnitTestSessionManager();
        }

        public new static UnitTestSessionManager Instance
        {
            get { return Nested.instance; }
        }

        #endregion

        protected override ISessionFactory BuildSessionFactory(params IInterceptor[] interceptors)
        {
            var listeMappingTypes = ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(typeof(IEntityMapping), typeof(EntityHistoryMapping).Assembly);
            var mapper = new ModelMapper();
            mapper.AddMappings(listeMappingTypes);

            base.Configuration = new Configuration()
                     .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                     .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                     .SetProperty(Environment.ConnectionString, "Data Source=test.db;new=True;UT8Encoding=True;");

            base.Configuration.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), string.Empty);
            foreach (var interceptor in interceptors)
            {
                base.Configuration.SetInterceptor(interceptor);
            }

            return base.Configuration.BuildSessionFactory();
        }

        protected override Hashtable ContextSessions
        {
            get
            {
                if (CallContext.GetData(ContextSessionsKey) == null)
                {
                    CallContext.SetData(ContextSessionsKey, new Hashtable());
                }

                return (Hashtable)CallContext.GetData(ContextSessionsKey);
            }
        }

        public override void BeginTransaction()
        {
            base.BeginTransaction();
        }

        public override void CommitTransaction()
        {
            base.CommitTransaction();

            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
                _sessionFactory.Dispose();
                _sessionFactory = null;
            }
        }
    }
}
