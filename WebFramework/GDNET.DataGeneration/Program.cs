using System;
using System.Reflection;
using GDNET.Business.Services;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.DataGeneration.SessionManagement;
using GDNET.Domain.Content;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Entities.System.ReferenceData;
using GDNET.Domain.Repositories;
using GDNET.Utils;
using NHibernate;

namespace GDNET.DataGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionStrategy = new DataRepositoryStrategy(DataGenerationNHibernateSessionManager.Instance);
            var repositories = new DataRepositories(sessionStrategy);
            var servicesManager = new ServicesManager();

            var user = DomainRepositories.User.FindByEmail("admin@webframework.com");
            var sessionContext = new DataSessionContext(user);

            DataGenerationNHibernateSessionManager.Instance.BeginTransaction();
            ISession currentSession = DataGenerationNHibernateSessionManager.Instance.GetSession();

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
            Random aRandom = new Random();
            Catalog catalogLanguage = DomainRepositories.Catalog.FindByCode(SystemCatalogs.Languages);

            int nbContentItems = aRandom.Next(10, 20);
            for (int index = 0; index < nbContentItems; index++)
            {
                int length = aRandom.Next(15, 50);
                string name = RandomAssistant.GenerateASentence(aRandom, length);
                var ci = ContentItem.Factory.Create(name, true);

                int languageIndex = aRandom.Next(0, catalogLanguage.Lines.Count - 1);
                ci.Language = catalogLanguage.Lines[languageIndex];

                ci.Description = RandomAssistant.GenerateAParagraph(aRandom);

                DomainRepositories.ContentItem.Save(ci);

                for (int partCounter = 0; partCounter < 10; partCounter++)
                {
                    int partLength = aRandom.Next(15, 50);
                    string partName = RandomAssistant.GenerateASentence(aRandom, length);
                    string details = string.Format("<p>{0}</p>", RandomAssistant.GenerateAParagraph(aRandom));

                    var cp = ContentPart.Factory.Create(partName, details, true);
                    ci.AddPart(cp);
                }
            }

            Console.Write("done!");
        }

        private static void GenerateUsers()
        {
            Console.WriteLine();
            Console.Write(MethodBase.GetCurrentMethod().Name + "...");
            Random random = new Random();

            for (int index = 0; index < 10; index++)
            {
                var email = RandomAssistant.GenerateEmailAddress(random);

                if (DomainRepositories.User.FindByEmail(email) == null)
                {
                    var user = User.Factory.Create(email, "@a1b2c3$", Convert.ToBoolean(random.Next(0, 1)));
                    DomainRepositories.User.Save(user);
                }
            }

            Console.Write("done!");
        }
    }
}
