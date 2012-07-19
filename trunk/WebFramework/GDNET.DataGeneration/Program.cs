using System;
using GDNET.Business.Services;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.DataGeneration.SessionManagement;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories;
using GDNET.Utils;
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

            Console.WriteLine();
            Console.Write("Finished...");
        }

        private static void GenerateUsers()
        {
            Console.WriteLine();
            Console.Write("GenerateUsers...");

            var guest = User.Factory.Create("guest@webframework", "123456");
            var admin = User.Factory.Create("admin@webframework", "123456");
            DomainRepositories.User.Save(guest);
            DomainRepositories.User.Save(admin);

            for (int index = 0; index < 10; index++)
            {
                var email = RandomAssistant.GenerateEmailAddress();
                var user = User.Factory.Create(email, "@a1b2c3$");
                DomainRepositories.User.Save(user);
            }

            Console.Write("done!");
        }
    }
}
