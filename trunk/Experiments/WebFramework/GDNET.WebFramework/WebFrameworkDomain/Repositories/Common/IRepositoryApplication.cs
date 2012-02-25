using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface IRepositoryApplication : IRepositoryBase<Application, long>
    {
        Application GetByRootUrl(string rootUrl);
    }
}
