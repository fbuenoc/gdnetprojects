using GDNET.NHibernate.Repositories;
using NHibernate;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentItem : AbstractRepository<ContentItem, long>, IRepositoryContentItem
    {
        public RepositoryContentItem(ISession session)
            : base(session)
        {
        }
    }
}
