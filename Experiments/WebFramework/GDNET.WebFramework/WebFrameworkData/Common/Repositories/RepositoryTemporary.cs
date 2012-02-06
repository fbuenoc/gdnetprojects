using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryTemporary : AbstractRepository<Temporary, string>, IRepositoryTemporary
    {
        public RepositoryTemporary(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
