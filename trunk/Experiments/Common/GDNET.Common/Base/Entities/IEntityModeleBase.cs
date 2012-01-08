namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity model with Id, IsActive property
    /// </summary>
    public interface IEntityModeleBase<TId> : IEntityBase<TId>
    {
        new TId Id
        {
            get;
            set;
        }
    }
}
