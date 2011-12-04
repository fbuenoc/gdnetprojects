namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id, IsActive property
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntityActiveBase<TId> : IEntityBase<TId>, IEntityActiveBase
    {
    }

    public interface IEntityActiveBase
    {
        bool IsActive
        {
            get;
            set;
        }
    }

}
