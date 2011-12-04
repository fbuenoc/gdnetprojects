using System;

using GDNET.Common.DesignByContract;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with with CreMod, Deletable, Editable, Viewable
    /// </summary>
    public abstract class EntityFullControlBase<TId> : EntityCreModBase<TId>, IEntityDeletable<TId>, IEntityEditable<TId>, IEntityViewable<TId>
    {
        public EntityFullControlBase() { }

        public EntityFullControlBase(EntityFullControlBase<TId> entity)
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
