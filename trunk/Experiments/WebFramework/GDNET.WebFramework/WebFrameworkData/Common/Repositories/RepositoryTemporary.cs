using GDNET.NHibernate.Repositories;
using NHibernate;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryTemporary : AbstractRepository<Temporary, string>, IRepositoryTemporary
    {
        public RepositoryTemporary(ISession session)
            : base(session)
        {
        }
    }
}
