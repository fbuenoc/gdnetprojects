using NHibernate;

using GDNET.NHibernateImpl.Data;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryTemporary : NHRepositoryBase<Temporary, string>, IRepositoryTemporary
    {
        public RepositoryTemporary(ISession session)
            : base(session)
        {
        }
    }
}
