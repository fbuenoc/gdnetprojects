using GDNET.NHibernateImpl.Data;
using NHibernate;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryTranslation : NHRepositoryBase<Translation, long>, IRepositoryTranslation
    {
        public RepositoryTranslation(ISession session)
            : base(session)
        {
        }

        #region IRepositoryTranslation Members

        public Translation GetByCode(string code)
        {
            var results = base.FindByProperty(TranslationMeta.Code, code, 0, 1);
            return (results != null && results.Count > 0) ? results[0] : null;
        }

        #endregion
    }
}
