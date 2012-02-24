using System;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Repositories.Common;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryTemporary : AbstractRepository<Temporary, Guid>, IRepositoryTemporary
    {
        public RepositoryTemporary(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
