using GDNET.Domain.System;
using GDNET.Domain.System.Repositories;
using GDNET.NHibernate.Repositories;

namespace GDNET.Data.System
{
    public class UserRepository : AbstractRepository<User, long>, IUserRepository
    {
        public UserRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
