using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

using GDNET.NHibernateImpl.Data;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryCategory : NHRepositoryBase<ListValue, long>, IRepositoryCategory
    {
        public RepositoryCategory(ISession session)
            : base(session)
        {
        }
    }
}
