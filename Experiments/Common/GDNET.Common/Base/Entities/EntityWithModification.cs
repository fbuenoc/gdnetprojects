namespace GDNET.Common.Base.Entities
{
    public abstract class EntityWithModification<TId> : EntityWithActive<TId>, IEntityWithModification<TId>
    {
        public EntityWithModification() { }

        public EntityWithModification(IEntityWithModification<TId> entity)
            : base(entity)
        {
            this.IsDeletable = entity.IsDeletable;
            this.IsEditable = entity.IsEditable;
        }

        #region IEntityWithModification Members

        public virtual bool IsActive
        {
            get;
            set;
        }

        public virtual bool IsDeletable
        {
            get;
            set;
        }

        public virtual bool IsEditable
        {
            get;
            set;
        }

        #endregion
    }
}
