using System;
using NHibernate;

using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentItem : NHRepositoryBase<ContentItem, long>, IRepositoryContentItem
    {
        public RepositoryContentItem(ISession session)
            : base(session)
        {
        }
    }
}
