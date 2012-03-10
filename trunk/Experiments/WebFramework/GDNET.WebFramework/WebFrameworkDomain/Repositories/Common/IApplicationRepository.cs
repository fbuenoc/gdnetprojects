using GDNET.Common.Data;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Repositories.Common
{
    public interface IApplicationRepository : IRepositoryBase<Application, long>
    {
        Application GetByRootUrl(string rootUrl);
    }
}
