using System;
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

        private DateTime startDate;

        [SetUp]
        public void SetUp()
        {
            var sessionStrategy = new DataSessionStrategy(UnitTestSessionManager.Instance);
            var repositories = new DataRepositories(sessionStrategy);
            var servicesManager = new ServicesManager();

            UnitTestSessionManager.Instance.BeginTransaction();
            ISession currentSession = UnitTestSessionManager.Instance.GetSession();
            (new SchemaExport(UnitTestSessionManager.Instance.Configuration)).Execute(true, true, false, currentSession.Connection, Console.Out);

            this.CurrentUser = User.Factory.Create("test@mail.com", "123456");
            var sessionContext = new DataSessionContext(this.CurrentUser);

            DomainRepositories.User.Save(this.CurrentUser);

            Console.WriteLine();
            Console.WriteLine("------------->>");
            this.startDate = DateTime.Now;
        }

        [TearDown]
        public void TearDown()
        {
            UnitTestSessionManager.Instance.CommitTransaction();
            Console.WriteLine();
            Console.WriteLine("<<-------------");
            Console.WriteLine(DateTime.Now - this.startDate);
        }
    }
}
