using GDNET.Common.Data;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.Repositories.Common
{
    public interface IRepositoryCulture : IRepositoryBase<Culture, int>
    {
        Culture FindByCode(string code);
    }
}
