using GDNET.Domain.Common;
using NHibernate;

namespace GDNET.NHibernate.SessionManagement
{
    public interface ISessionStrategy : IRepositoryManager
    {
        ISession Session { get; }
    }
}
