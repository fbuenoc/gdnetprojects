using System;
using GDNET.Domain.Common;
using GDNET.Domain.Content;

namespace GDNET.Domain.Repositories.Content
{
    public interface IContentItemRepository : IRepositoryBase<ContentItem, Guid>
    {
    }
}
