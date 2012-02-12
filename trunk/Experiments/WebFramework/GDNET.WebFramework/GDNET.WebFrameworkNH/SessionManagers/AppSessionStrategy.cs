using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFrameworkNHibernate.SessionManagers
{
    public sealed class AppSessionStrategy : AbstractSessionStrategy
    {
        public AppSessionStrategy(ISession session)
            : base(session)
        {
        }
    }
}
