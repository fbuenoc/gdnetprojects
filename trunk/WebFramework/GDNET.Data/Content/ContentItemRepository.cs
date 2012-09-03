using System;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories.Content;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;

namespace GDNET.Data.Content
{
    public class ContentItemRepository : AbstractRepository<ContentItem, Guid>, IContentItemRepository
    {
        public ContentItemRepository(INHibernateRepositoryStrategy strategy)
            : base(strategy)
        {
        }
    }
}
