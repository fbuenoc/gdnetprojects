using GDNET.Common.Data;
using NHibernate;

namespace GDNET.NHibernate.SessionManagers
{
    public interface ISessionStrategy : IRepositoryAssistant
    {
        ISession Session { get; }
    }
}
