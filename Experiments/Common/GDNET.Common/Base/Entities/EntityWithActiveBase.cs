namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id property
    /// </summary>
    public abstract class EntityWithActiveBase<TId> : EntityBase<TId>, IEntityWithActiveBase<TId>
    {
        public EntityWithActiveBase()
            : base()
        {
        }

        public EntityWithActiveBase(IEntityWithActiveBase<TId> entity)
            : base(entity)
        {
            this.IsActive = entity.IsActive;
        }

        #region IEntityWithActiveBase<TId> Members

        public virtual bool IsActive
        {
            get;
            set;
        }

        #endregion

    }
}
