using System;
using NHibernate;

using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentType : NHRepositoryBase<ContentType, long>, IRepositoryContentType
    {
        public RepositoryContentType(ISession session)
            : base(session)
        {
        }
    }
}
