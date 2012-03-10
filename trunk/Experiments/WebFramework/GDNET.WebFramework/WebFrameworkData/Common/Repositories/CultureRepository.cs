using System.Linq;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Repositories.Common;

namespace WebFramework.Data.Common.Repositories
{
    public class CultureRepository : AbstractRepository<Culture, int>, ICultureRepository
    {
        public CultureRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public Culture FindByCode(string cultureCode)
        {
            var results = this.FindByProperty(CommonConstants.CultureMeta.CultureCode, cultureCode);
            return (results.Count == 0) ? null : results[0];
        }

        public Culture GetDefault()
        {
            var results = this.FindByProperty(CommonConstants.CultureMeta.IsDefault, true);
            return results.FirstOrDefault();
        }
    }
}
