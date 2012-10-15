using System;
using System.Collections.Generic;
using GDNET.Base.DomainRepository;
using GDNET.Domain.Content;

namespace GDNET.Domain.Repositories.Content
{
    public interface IContentItemRepository : IRepositoryBase<ContentItem, Guid>
    {
        IList<ContentItem> GetTopWithActive(int limit);
        IList<ContentItem> GetTopWithActiveByViews(int limit);
        IList<ContentItem> GetTopWithActiveByViews(int limit, Guid itemIdExclude);
        IList<ContentItem> GetTopWithActiveByAuthor(int limit, string authorEmail);

        IList<ContentItem> SearchTopWithActive(int limit, string query);
    }
}
