using GDNET.Domain.Common;

namespace GDNET.Domain.System.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, long>
    {
        User FindByEmail(string email);
    }
}
