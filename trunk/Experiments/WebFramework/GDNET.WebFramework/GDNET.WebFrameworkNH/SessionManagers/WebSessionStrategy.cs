using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFrameworkNHibernate.SessionManagers
{
    public class WebSessionStrategy : AbstractSessionStrategy
    {
        public WebSessionStrategy(ISession session)
            : base(session)
        {
        }
    }
}
