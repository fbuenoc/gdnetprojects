using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Common;
using WebFramework.Domain.Repositories.Common;

namespace WebFramework.Data.Common.Repositories
{
    public class ContentAttributeRepository : AbstractRepository<ContentAttribute, long>, IContentAttributeRepository
    {
        public ContentAttributeRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
