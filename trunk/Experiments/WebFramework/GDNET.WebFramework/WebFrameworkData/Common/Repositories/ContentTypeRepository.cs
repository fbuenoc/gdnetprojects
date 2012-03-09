using System;
using GDNET.Extensions;
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

        public ContentType FindByTypeName(string qualifiedTypeName)
        {
            var results = this.FindByProperty(CommonConstants.ContentTypeMeta.TypeName, qualifiedTypeName);
            return (results.Count == 0) ? null : results[0];
        }

        public ContentType FindByType(Type typeOfContentType)
        {
            string qualifiedTypeName = typeOfContentType.GetQualifiedTypeName();
            return this.FindByTypeName(qualifiedTypeName);
        }
    }
}
