using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.Repositories.Common;

namespace WebFrameworkData.Common.Repositories
{
    public class ContentTypeRepository : AbstractRepository<ContentType, long>, IContentTypeRepository
    {
        public ContentTypeRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public ContentType FindByTypeName(string typeName)
        {
            var results = this.FindByProperty(CommonConstants.ContentTypeMeta.TypeName, typeName);
            return (results.Count == 0) ? null : results[0];
        }
    }
}
