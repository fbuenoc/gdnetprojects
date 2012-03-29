using GDNET.Common.Data;
using WebFramework.Domain.Common;

namespace WebFramework.Domain.Repositories.Common
{
    public interface ICultureRepository : IRepositoryWithActiveBase<Culture, int>
    {
        Culture FindByCode(string code);
        Culture GetDefault();
    }
}
