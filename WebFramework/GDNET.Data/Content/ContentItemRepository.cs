using System;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories.Content;
using GDNET.NHibernate.Repositories;

namespace GDNET.Data.Content
{
    public class ContentItemRepository : AbstractRepository<ContentItem, Guid>, IContentItemRepository
    {
        public ContentItemRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
