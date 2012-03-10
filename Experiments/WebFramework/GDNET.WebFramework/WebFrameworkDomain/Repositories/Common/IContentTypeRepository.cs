using System;
using GDNET.Common.Data;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Repositories.Common
{
    public interface IContentTypeRepository : IRepositoryBase<ContentType, long>
    {
        ContentType FindByTypeName(string qualifiedTypeName);
        ContentType FindByType(Type typeOfContentType);
    }
}
