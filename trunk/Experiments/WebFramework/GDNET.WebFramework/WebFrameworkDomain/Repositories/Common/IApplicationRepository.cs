using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface IApplicationRepository : IRepositoryBase<Application, long>
    {
        Application GetByRootUrl(string rootUrl);
    }
}
