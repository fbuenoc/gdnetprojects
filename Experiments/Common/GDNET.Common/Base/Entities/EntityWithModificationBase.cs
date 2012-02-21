namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with with CreMod
    /// </summary>
    public abstract class EntityWithModificationBase<TId> : EntityBase<TId>, IEntityWithModification<TId>
    {
        public EntityWithModificationBase() { }

        public EntityWithModificationBase(IEntityWithModification<TId> entity)
            : base(entity)
        {
            this.IsActive = entity.IsActive;
            this.IsDeletable = entity.IsDeletable;
            this.IsEditable = entity.IsEditable;
            this.IsViewable = entity.IsViewable;
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

        public virtual bool IsViewable
        {
            get;
            set;
        }

        #endregion
    }
}
