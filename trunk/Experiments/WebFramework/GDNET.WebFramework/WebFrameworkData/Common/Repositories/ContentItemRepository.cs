using System;
using System.Collections.Generic;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;
using WebFrameworkDomain.Repositories.Common;

namespace WebFrameworkData.Common.Repositories
{
    public class ContentItemRepository : AbstractRepository<ContentItem, long>, IContentItemRepository
    {
        public ContentItemRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public IList<ContentItem> GetByContentType(ContentType contentType)
        {
            return base.FindByProperty(CommonConstants.ContentItemMeta.ContentType, contentType);
        }

        public IList<ContentItem> GetByContentType(Type typeOfContentType)
        {
            ContentType contentType = DomainRepositories.ContentType.FindByType(typeOfContentType);
            return this.GetByContentType(contentType);
        }
    }
}
