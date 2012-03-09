using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.Repositories.Common;

namespace WebFrameworkData.Common.Repositories
{
    public class TranslationRepository : AbstractRepository<Translation, long>, ITranslationRepository
    {
        public TranslationRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        #region IRepositoryTranslation Members

        public Translation GetByCode(string code)
        {
            var results = base.FindByProperty(CommonConstants.TranslationMeta.Code, code, 0, 1);
            return (results != null && results.Count > 0) ? results[0] : null;
        }

        public Translation GetByCode(string code, Culture culture)
        {
            var properties = new string[] { CommonConstants.TranslationMeta.Code, CommonConstants.TranslationMeta.Culture };
            var values = new object[] { code, culture };
            var results = base.FindByProperties(properties, values);
            return (results != null && results.Count > 0) ? results[0] : null;
        }

        #endregion

    }
}
