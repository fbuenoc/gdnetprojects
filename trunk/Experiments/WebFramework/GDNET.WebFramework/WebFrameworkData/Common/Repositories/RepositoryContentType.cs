using GDNET.NHibernate.Repositories;
using NHibernate;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Repositories;

namespace WebFrameworkData.Common.Repositories
{
    public class RepositoryContentType : AbstractRepository<ContentType, long>, IRepositoryContentType
    {
        public RepositoryContentType(ISession session)
            : base(session)
        {
        }

        public ContentType FindByTypeName(string typeName)
        {
            var results = this.FindByProperty(ContentTypeMeta.TypeName, typeName);
            return (results.Count == 0) ? null : results[0];
        }
    }
}
