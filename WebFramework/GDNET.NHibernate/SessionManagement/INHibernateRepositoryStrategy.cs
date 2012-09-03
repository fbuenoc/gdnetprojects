using GDNET.Domain.Common;
using NHibernate;

namespace GDNET.NHibernate.SessionManagement
{
    public interface INHibernateRepositoryStrategy : IRepositoryStrategy
    {
        ISession Session { get; }
    }
}
