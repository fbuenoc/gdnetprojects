namespace GDNET.Common.Base.Entities
{
    public abstract class EntityWithActive<TId> : EntityBase<TId>, IEntityWithActive<TId>
    {
        public EntityWithActive()
            : base()
        {
        }

        public EntityWithActive(IEntityWithActive<TId> entity)
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
