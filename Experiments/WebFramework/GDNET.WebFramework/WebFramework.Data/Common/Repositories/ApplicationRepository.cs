﻿using System.Linq;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Repositories.Common;

namespace WebFramework.Data.Common.Repositories
{
    public class ApplicationRepository : AbstractRepository<Application, long>, IApplicationRepository
    {
        public ApplicationRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        #region IRepositoryTranslation Members

        public Application GetByRootUrl(string rootUrl)
        {
            var results = base.FindByProperty(MetaInfos.ApplicationMeta.RootUrl, rootUrl, 0, 1);
            return (results != null && results.Count > 0) ? results[0] : null;
        }

        public Application GetByRootUrl(string rootUrl, bool includeDefaultApp)
        {
            if (includeDefaultApp)
            {
                var applications = base.FindByProperty(MetaInfos.ApplicationMeta.RootUrl, new string[] { rootUrl, CommonConstants.DefaultApplicationRootUrl });
                if (applications.Count == 1)
                {
                    return applications[0];
                }
                else
                {
                    return applications.FirstOrDefault(x => x.RootUrl == rootUrl);
                }
            }
            else
            {
                return this.GetByRootUrl(rootUrl);
            }
        }

        #endregion

    }
}
