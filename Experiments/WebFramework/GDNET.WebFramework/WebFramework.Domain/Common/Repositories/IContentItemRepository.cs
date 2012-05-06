using System;
using System.Collections.Generic;
using GDNET.Common.Data;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Repositories.Common
{
    public interface IContentItemRepository : IRepositoryBase<ContentItem, long>
    {
        IList<ContentItem> GetByContentType(ContentType contentType);
        IList<ContentItem> GetByContentType(Type typeOfContentType);
        IList<ContentItem> GetByContentType(Type typeOfContentType, int nbItems);
    }
}
