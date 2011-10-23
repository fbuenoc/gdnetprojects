namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id, IsActive property
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntity<TId>
    {
        TId Id
        {
            get;
            set;
        }

        bool IsActive
        {
            get;
            set;
        }
    }
}
