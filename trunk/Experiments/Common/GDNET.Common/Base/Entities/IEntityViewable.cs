namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with IsViewable property
    /// </summary>
    public interface IEntityViewable<TId> : IEntityActiveBase<TId>
    {
        bool IsViewable
        {
            get;
            set;
        }
    }
}
