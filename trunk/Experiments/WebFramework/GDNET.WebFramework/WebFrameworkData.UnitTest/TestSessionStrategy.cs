using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFrameworkData.UnitTest
{
    public class TestSessionStrategy : AbstractSessionStrategy
    {
        public TestSessionStrategy(ISession session)
            : base(session)
        {
        }
    }
}
