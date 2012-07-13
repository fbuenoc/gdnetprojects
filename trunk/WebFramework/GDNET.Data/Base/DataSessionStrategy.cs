using GDNET.NHibernate.SessionManagement;
using NHibernate;

namespace GDNET.Data.Base
{
    public class DataSessionStrategy : AbstractSessionStrategy
    {
        public DataSessionStrategy(ISession nhSession)
            : base(nhSession)
        {
        }
    }
}
