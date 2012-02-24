using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Repositories.Common;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentAttribute : AbstractRepository<ContentAttribute, long>, IRepositoryContentAttribute
    {
        public RepositoryContentAttribute(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
