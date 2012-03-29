using GDNET.Common.Data;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Repositories.Common
{
    public interface IApplicationRepository : IRepositoryWithActiveBase<Application, long>
    {
        Application GetByRootUrl(string rootUrl);
    }
}
