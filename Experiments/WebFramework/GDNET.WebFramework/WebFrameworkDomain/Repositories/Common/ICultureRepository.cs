using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface ICultureRepository : IRepositoryBase<Culture, int>
    {
        Culture FindByCode(string code);
        Culture GetDefault();
    }
}
