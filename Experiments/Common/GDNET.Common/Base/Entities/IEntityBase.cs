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
            set;
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
