using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentType : AbstractRepository<ContentType, long>, IRepositoryContentType
    {
        public RepositoryContentType(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public ContentType FindByTypeName(string typeName)
        {
            var results = this.FindByProperty(ContentTypeMeta.TypeName, typeName);
            return (results.Count == 0) ? null : results[0];
        }
    }
}
