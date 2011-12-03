using System;

using NHibernate;

using GDNET.NHibernateImpl.Data;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryListValue : NHRepositoryBase<ListValue, long>, IRepositoryListValue
    {
        public RepositoryListValue(ISession session)
            : base(session)
        {
        }

        public ListValue FindByName(string name)
        {
            var results = this.FindByProperty(ListValueMeta.Name, name);
            return (results.Count == 0) ? null : results[0];
        }
    }
}
