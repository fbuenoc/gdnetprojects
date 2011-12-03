using GDNET.Common.Data;

namespace WebFrameworkDomain.Common.Repositories
{
    public interface IRepositoryApplication : IRepositoryBase<Application, long>
    {
        Application GetByRootUrl(string rootUrl);
    }
}
