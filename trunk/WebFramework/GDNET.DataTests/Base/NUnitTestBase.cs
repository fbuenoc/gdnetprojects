using GDNET.Business.Services;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Console = System.Console;

namespace GDNET.DataTests.Base
{
    public class NUnitTestBase
    {
        protected User CurrentUser
        {
            get;
            private set;
        }

        [SetUp]
        public void SetUp()
        {
            UnitTestSessionManager.Instance.BeginTransaction();
            ISession currentSession = UnitTestSessionManager.Instance.GetSession();

            (new SchemaExport(UnitTestSessionManager.Instance.Configuration)).Execute(true, true, false, currentSession.Connection, Console.Out);

            var sessionStrategy = new DataSessionStrategy(currentSession);
            var repositories = new DataRepositories(sessionStrategy);
            var servicesManager = new ServicesManager();

            this.CurrentUser = User.Factory.Create("test@mail.com", "123456");
            var sessionContext = new DataSessionContext(this.CurrentUser);

            DomainRepositories.User.Save(this.CurrentUser);
        }

        [TearDown]
        public void TearDown()
        {
            UnitTestSessionManager.Instance.CommitTransaction();
        }
    }
}
