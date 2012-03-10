using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFramework.Data.UnitTest
{
    public class TestSessionStrategy : AbstractSessionStrategy
    {
        public TestSessionStrategy(ISession session)
            : base(session)
        {
        }
    }
}
