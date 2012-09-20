using System;
using System.Collections.Generic;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories.Content;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;
using GDNET.Utils;

namespace GDNET.Data.Content
{
    public class ContentItemRepository : AbstractRepository<ContentItem, Guid>, IContentItemRepository
    {
        private static readonly ContentItem DefaultContentItem = default(ContentItem);

        public ContentItemRepository(INHibernateRepositoryStrategy strategy)
            : base(strategy)
        {
        }

        public IList<ContentItem> GetTopWithActive(int limit)
        {
            var propertyCreatedAt = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.CreatedAt);
            var propertyIsActive = ExpressionAssistant.GetPropertyName(() => DefaultContentItem.IsActive);

            return base.GetTopByProperty(limit, propertyCreatedAt, new List<string> { propertyIsActive }, new List<object> { true });
        }
    }
}
