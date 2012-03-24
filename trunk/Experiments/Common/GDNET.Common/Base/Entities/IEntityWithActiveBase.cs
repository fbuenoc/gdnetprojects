namespace GDNET.Common.Base.Entities
{
    public interface IEntityWithActiveBase : IEntityBase
    {
        bool IsActive
        {
            get;
            set;
        }
    }

    public interface IEntityWithActiveBase<TId> : IEntityBase<TId>, IEntityWithActiveBase
    {
    }
}
