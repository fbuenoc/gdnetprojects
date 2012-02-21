namespace GDNET.Common.Base.Entities
{
    public interface IEntityBase
    {
        string Signature
        {
            get;
        }
    }

    /// <summary>
    /// Entity with Id
    /// </summary>
    public interface IEntityBase<TId> : IEntityBase
    {
        TId Id
        {
            get;
        }
    }
}
