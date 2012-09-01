using GDNET.NHibernate.SessionManagement;

namespace GDNET.Data.Base
{
    public class DataSessionStrategy : AbstractSessionStrategy
    {
        public DataSessionStrategy(INHibernateSessionManager sessionManager)
            : base(sessionManager)
        {
        }
    }
}
