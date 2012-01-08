namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with with CreMod, Deletable, Editable, Viewable
    /// </summary>
    public abstract class EntityWithFullInfoBase<TId> : EntityWithModificationBase<TId>, IDeletable, IEditable, IViewable
    {
        public EntityWithFullInfoBase() { }

        public EntityWithFullInfoBase(EntityWithFullInfoBase<TId> entity)
            : base(entity)
        {
            this.IsDeletable = entity.IsDeletable;
            this.IsEditable = entity.IsEditable;
            this.IsViewable = entity.IsViewable;
        }

        #region IEntityDeletable Members

        public virtual bool IsDeletable
        {
            get;
            set;
        }

        #endregion

        #region IEntityEditable Members

        public virtual bool IsEditable
        {
            get;
            set;
        }

        #endregion

        #region IEntityViewable Members

        public virtual bool IsViewable
        {
            get;
            set;
        }

        #endregion
    }
}
