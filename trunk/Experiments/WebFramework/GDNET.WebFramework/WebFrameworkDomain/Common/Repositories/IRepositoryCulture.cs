using GDNET.Common.Data;

namespace WebFrameworkDomain.Common.Repositories
{
    public interface IRepositoryCulture : IRepositoryBase<Culture, int>
    {
        Culture FindByCode(string code);
    }
}
