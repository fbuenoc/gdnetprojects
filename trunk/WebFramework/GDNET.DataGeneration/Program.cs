using GDNET.Business.Services;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.DataGeneration.SessionManagement;
using GDNET.Domain;
using GDNET.Domain.System;
using NHibernate;

namespace GDNET.DataGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerationNHibernateSessionManager.Instance.BeginTransaction();
            ISession currentSession = DataGenerationNHibernateSessionManager.Instance.GetSession();

            var sessionStrategy = new DataSessionStrategy(currentSession);
            var repositories = new DataRepositories(sessionStrategy);
            var servicesManager = new ServicesManager();

            #region Users

            GenerateUsers();

            #endregion

            DataGenerationNHibernateSessionManager.Instance.CommitTransaction();
        }

        private static void GenerateUsers()
        {
            var guest = User.Factory.Create("guest@webframework", "123456");
            var admin = User.Factory.Create("admin@webframework", "123456");
            DomainRepositories.User.Save(guest);
            DomainRepositories.User.Save(admin);
        }
    }
}
