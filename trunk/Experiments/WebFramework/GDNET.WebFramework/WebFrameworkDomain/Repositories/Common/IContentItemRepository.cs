using System;
using System.Collections.Generic;
using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface IContentItemRepository : IRepositoryBase<ContentItem, long>
    {
        IList<ContentItem> GetByContentType(ContentType contentType);
        IList<ContentItem> GetByContentType(Type typeOfContentType);
    }
}
