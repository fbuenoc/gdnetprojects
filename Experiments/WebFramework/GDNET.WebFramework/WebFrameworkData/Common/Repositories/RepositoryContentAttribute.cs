using System;
using NHibernate;

using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentAttribute : NHRepositoryBase<ContentAttribute, long>, IRepositoryContentAttribute
    {
        public RepositoryContentAttribute(ISession session)
            : base(session)
        {
        }
    }
}
