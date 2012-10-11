using GDNET.Base.DomainAbstraction;

namespace GDNET.Domain.Entities.System.Management
{
    public interface IEntityWithModificationHistoryT<TId> : IEntityWithModificationT<TId>, IEntityWithModificationHistory
    {
    }
}
