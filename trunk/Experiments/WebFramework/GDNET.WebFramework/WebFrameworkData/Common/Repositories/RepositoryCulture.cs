using GDNET.NHibernate.Repositories;
using NHibernate;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryCulture : AbstractRepository<Culture, int>, IRepositoryCulture
    {
        public RepositoryCulture(ISession session)
            : base(session)
        {
        }

        public Culture FindByCode(string cultureCode)
        {
            var results = this.FindByProperty(CultureMeta.CultureCode, cultureCode);
            return (results.Count == 0) ? null : results[0];
        }
    }
}
