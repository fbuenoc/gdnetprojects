using GDNET.NHibernate.Repositories;
using NHibernate;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentAttribute : AbstractRepository<ContentAttribute, long>, IRepositoryContentAttribute
    {
        public RepositoryContentAttribute(ISession session)
            : base(session)
        {
        }
    }
}
