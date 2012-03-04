using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFrameworkNHibernate.SessionManagers
{
    public sealed class WebSessionStrategy : AbstractSessionStrategy
    {
        public WebSessionStrategy(ISession session)
            : base(session)
        {
        }
    }
}
