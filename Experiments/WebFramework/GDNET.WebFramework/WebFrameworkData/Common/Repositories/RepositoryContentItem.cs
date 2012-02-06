using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentItem : AbstractRepository<ContentItem, long>, IRepositoryContentItem
    {
        public RepositoryContentItem(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
