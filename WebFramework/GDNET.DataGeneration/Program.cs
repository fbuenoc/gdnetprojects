using System;
using System.Reflection;
using GDNET.Business.Services;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.DataGeneration.SessionManagement;
using GDNET.Domain.Content;
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

            #region Contents

            GenerateContentItems();

            #endregion

            DataGenerationNHibernateSessionManager.Instance.CommitTransaction();

            Console.WriteLine();
            Console.Write("Finished...");
        }

        private static void GenerateContentItems()
        {
            Console.WriteLine();
            Console.Write(MethodBase.GetCurrentMethod().Name + "...");

            int nbContentItems = new Random().Next(10, 20);
            for (int index = 0; index < nbContentItems; index++)
            {
                string name = "Content item #" + (index + 1);
                var ci = ContentItem.Factory.Create(name, true);
                DomainRepositories.ContentItem.Save(ci);

                for (int partCounter = 0; partCounter < 10; partCounter++)
                {
                    var cp = ContentPart.Factory.Create("Part " + (partCounter + 1), RandomAssistant.GenerateASentence(), true);
                    ci.AddPart(cp);
                }
            }

            Console.Write("done!");
        }

        private static void GenerateUsers()
        {
            Console.WriteLine();
            Console.Write(MethodBase.GetCurrentMethod().Name + "...");

            var guest = User.Factory.Create("guest@webframework", "123456", true);
            var admin = User.Factory.Create("admin@webframework", "123456", true);
            DomainRepositories.User.Save(guest);
            DomainRepositories.User.Save(admin);

            for (int index = 0; index < 10; index++)
            {
                var email = RandomAssistant.GenerateEmailAddress();

                if (DomainRepositories.User.FindByEmail(email) == null)
                {
                    var user = User.Factory.Create(email, "@a1b2c3$");
                    DomainRepositories.User.Save(user);
                }
            }

            Console.Write("done!");
        }
    }
}
