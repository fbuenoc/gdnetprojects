using GDNET.Domain.Base;
using NHibernate;

namespace GDNET.NHibernate.Repositories
{
    public interface ISessionStrategy : IRepositoryManager
    {
        ISession Session { get; }
    }
}
