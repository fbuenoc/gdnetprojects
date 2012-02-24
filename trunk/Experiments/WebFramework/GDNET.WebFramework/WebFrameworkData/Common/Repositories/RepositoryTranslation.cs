using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.Repositories.Common;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryTranslation : AbstractRepository<Translation, long>, IRepositoryTranslation
    {
        public RepositoryTranslation(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        #region IRepositoryTranslation Members

        public Translation GetByCode(string code)
        {
            var results = base.FindByProperty(CommonConstants.TranslationMeta.Code, code, 0, 1);
            return (results != null && results.Count > 0) ? results[0] : null;
        }

        #endregion
    }
}
