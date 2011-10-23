namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with IsEditable property
    /// </summary>
    public interface IEntityEditable<TId> : IEntity<TId>
    {
        bool IsEditable
        {
            get;
            set;
        }
    }
}
