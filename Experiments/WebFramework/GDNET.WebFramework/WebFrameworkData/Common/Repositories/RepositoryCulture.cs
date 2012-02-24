using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.Repositories.Common;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryCulture : AbstractRepository<Culture, int>, IRepositoryCulture
    {
        public RepositoryCulture(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public Culture FindByCode(string cultureCode)
        {
            var results = this.FindByProperty(CommonConstants.CultureMeta.CultureCode, cultureCode);
            return (results.Count == 0) ? null : results[0];
        }
    }
}
