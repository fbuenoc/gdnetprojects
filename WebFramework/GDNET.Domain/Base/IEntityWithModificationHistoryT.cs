namespace GDNET.Domain.Base
{
    public interface IEntityWithModificationHistoryT<TId> : IEntityWithModificationT<TId>, IEntityWithModificationHistory
    {
    }
}
