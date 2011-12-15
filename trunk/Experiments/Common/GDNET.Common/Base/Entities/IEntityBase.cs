namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id, IsActive property
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntityBase<TId> : IEntitySignature
    {
        TId Id
        {
            get;
        }
    }

    public interface IEntitySignature
    {
        string Signature
        {
            get;
        }
    }
}
