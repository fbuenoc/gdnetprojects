using System;
using GDNET.Domain.Common;
using GDNET.Domain.Entities.System;

namespace GDNET.Domain.Repositories.System
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        User FindByEmail(string email);
    }
}
