using GDNET.NHibernate.SessionManagement;
using NHibernate;

namespace GDNET.DataTests.Base
{
    public class UnitTestSessionStrategy : AbstractSessionStrategy
    {
        public UnitTestSessionStrategy(ISession nhSession)
            : base(nhSession)
        {
        }
    }
}
