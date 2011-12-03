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
    public class RepositoryApplication : NHRepositoryBase<Application, long>, IRepositoryApplication
    {
        public RepositoryApplication(ISession session)
            : base(session)
        {
        }

        #region IRepositoryTranslation Members

        public Application GetByRootUrl(string rootUrl)
        {
            var results = base.FindByProperty(ApplicationMeta.RootUrl, rootUrl, 0, 1);
            return (results != null && results.Count > 0) ? results[0] : null;
        }

        #endregion
    }
}
