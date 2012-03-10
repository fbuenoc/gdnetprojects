using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFramework.NHibernate.SessionManagers
{
    public sealed class WebSessionStrategy : AbstractSessionStrategy
    {
        public WebSessionStrategy(ISession session)
            : base(session)
        {
        }
    }
}
