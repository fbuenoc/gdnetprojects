using System;
using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface IContentTypeRepository : IRepositoryBase<ContentType, long>
    {
        ContentType FindByTypeName(string qualifiedTypeName);
        ContentType FindByType(Type typeOfContentType);
    }
}
