namespace GDNET.Domain.Base
{
    public interface IEntityWithModificationHistoryT<TId> : IEntityT<TId>, IEntityWithModificationHistory
    {
    }
}
