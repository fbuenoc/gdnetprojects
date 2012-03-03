using System;
using NHibernate;
using WebFrameworkNHibernate.SessionManagers;

namespace WebFrameworkSampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            ISession session = AppStaticSessionManager.Instance.OpenSession();
            session.BeginTransaction();

            DataAssistant.Initialize(session);

            DataAssistant.InitializeContentTypes();
            if (args.Length > 0 && args[0] == "/s:data")
            {
                DataAssistant.GenerateSampleContents();
            }

            session.Flush();
            session.Transaction.Commit();
            session.Transaction.Dispose();

            Console.WriteLine("Done in (" + (DateTime.Now - date1) + ")");
            Console.ReadLine();
        }
    }
}
