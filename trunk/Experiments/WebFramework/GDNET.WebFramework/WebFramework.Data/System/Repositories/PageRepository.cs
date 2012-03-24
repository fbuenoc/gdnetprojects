using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Repositories.System;
using WebFramework.Domain.System;

namespace WebFramework.Data.System.Repositories
{
    public class PageRepository : AbstractRepository<Page, long>, IPageRepository
    {
        public PageRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
