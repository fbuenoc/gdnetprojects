using GDNET.NHibernate.SessionManagers;
using NHibernate;

namespace WebFramework.NHibernate.SessionManagers
{
    public sealed class AppSessionStrategy : AbstractSessionStrategy
    {
        public AppSessionStrategy(ISession session)
            : base(session)
        {
        }
    }
}
