using System;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.System;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;
using GDNET.Utils;

namespace GDNET.Data.System
{
    public class UserRepository : AbstractRepository<User, Guid>, IUserRepository
    {
        public UserRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public User FindByEmail(string email)
        {
            var defaultUser = default(User);
            string emailProperty = ExpressionAssistant.GetPropertyName(() => defaultUser.Email);

            var listOfUsers = base.FindByProperty(emailProperty, email);
            return (listOfUsers.Count > 0) ? listOfUsers[0] : null;
        }
    }
}
