using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Repositories.System;
using WebFramework.Domain.System;

namespace WebFramework.Data.System.AdminRepositories
{
    public class AdminPageRepository : AbstractRepositoryWithActive<Page, long>, IPageRepository
    {
        public AdminPageRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public Page GetByUniqueName(string uniqueName)
        {
            var pages = base.FindByProperty(MetaInfos.PageMeta.UniqueName, uniqueName);
            if (pages.Count == 1)
            {
                return pages[0];
            }

            return null;
        }
    }
}
