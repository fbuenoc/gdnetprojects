namespace GDNET.Domain.Base
{
    public interface IEntityT<TId> : IEntity
    {
        TId Id { get; }
    }
}
