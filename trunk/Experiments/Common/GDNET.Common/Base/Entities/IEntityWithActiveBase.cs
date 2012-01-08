namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id, IsActive property
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntityWithActiveBase<TId> : IEntityBase<TId>
    {
        bool IsActive
        {
            get;
            set;
        }
    }
}
