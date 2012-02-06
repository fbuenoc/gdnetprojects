using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryApplication : AbstractRepository<Application, long>, IRepositoryApplication
    {
        public RepositoryApplication(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
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
