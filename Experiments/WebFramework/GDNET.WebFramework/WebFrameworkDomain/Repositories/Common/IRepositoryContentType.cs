using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface IRepositoryContentType : IRepositoryBase<ContentType, long>
    {
        ContentType FindByTypeName(string typeName);
    }
}
