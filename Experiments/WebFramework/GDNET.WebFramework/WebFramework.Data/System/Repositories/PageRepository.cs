using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Constants;
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

        public Page GetByUniqueName(string uniqueName)
        {
            var pages = this.FindByProperty(MetaInfos.PageMeta.UniqueName, uniqueName);
            if (pages.Count == 1)
            {
                return pages[0];
            }

            return null;
        }
    }
}
