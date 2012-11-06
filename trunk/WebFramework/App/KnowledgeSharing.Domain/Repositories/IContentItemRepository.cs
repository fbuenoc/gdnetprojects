using System;
using System.Collections.Generic;
using GDNET.Base.DomainRepository;
using KnowledgeSharing.Domain.Entities;

namespace KnowledgeSharing.Domain.Repositories
{
    public interface IContentItemRepository : IRepositoryBase<ContentItem, Guid>
    {
        IList<ContentItem> GetAllByAuthor(string createdByEmail);

        IList<ContentItem> GetTopWithActive(int limit);
        IList<ContentItem> GetTopWithActiveByViews(int limit);
        IList<ContentItem> GetTopWithActiveByViews(int limit, Guid itemIdExclude);
        IList<ContentItem> GetTopWithActiveByAuthor(int limit, string authorEmail);

        IList<ContentItem> SearchTopWithActive(int limit, string query);
    }
}
