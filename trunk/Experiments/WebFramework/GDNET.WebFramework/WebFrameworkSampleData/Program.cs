using NHibernate;
using WebFrameworkNHibernate.SessionManagers;

namespace WebFrameworkSampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            ISession session = AppStaticSessionManager.Instance.OpenSession();
            session.BeginTransaction();

            DataAssistant.Initialize(session);

            DataAssistant.GenerateContentTypes();

            session.Transaction.Commit();
        }
    }
}
