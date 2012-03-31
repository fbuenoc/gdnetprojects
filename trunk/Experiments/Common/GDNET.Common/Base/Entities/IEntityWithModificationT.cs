namespace GDNET.Common.Base.Entities
{
    public interface IEntityWithModification<TId> : IEntityWithActive<TId>, IEntityWithModification
    {
    }
}
