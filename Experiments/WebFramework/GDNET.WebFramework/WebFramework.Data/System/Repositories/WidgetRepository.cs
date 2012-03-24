using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Repositories.System;
using WebFramework.Domain.System;

namespace WebFramework.Data.System.Repositories
{
    public class WidgetRepository : AbstractRepository<Widget, long>, IWidgetRepository
    {
        public WidgetRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
