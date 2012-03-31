namespace GDNET.Common.Base.Entities
{
    public interface IEntityBase<TId> : IEntityBase
    {
        TId Id
        {
            get;
        }
    }
}
