namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id, IsActive property
    /// </summary>
    public interface IEntityBase<TId> : ISignature
    {
        TId Id
        {
            get;
        }
    }
}
