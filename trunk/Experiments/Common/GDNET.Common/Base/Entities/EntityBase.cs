namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id property
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class EntityBase<TId> : IEntity<TId>
    {
        #region IEntity<TId> Members

        public TId Id
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        #endregion
    }
}
