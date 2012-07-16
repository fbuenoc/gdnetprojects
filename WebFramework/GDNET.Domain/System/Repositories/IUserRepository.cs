using GDNET.Domain.Common;
using System;

namespace GDNET.Domain.System.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        User FindByEmail(string email);
    }
}
