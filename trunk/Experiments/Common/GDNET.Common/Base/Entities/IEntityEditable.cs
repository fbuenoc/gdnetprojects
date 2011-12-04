namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with IsEditable property
    /// </summary>
    public interface IEntityEditable<TId> : IEntityActiveBase<TId>
    {
        bool IsEditable
        {
            get;
            set;
        }
    }
}
