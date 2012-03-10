using System;
using System.Collections.Generic;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.DefaultImpl;
using WebFramework.Domain.Repositories.Common;

namespace WebFramework.Data.Common.Repositories
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
