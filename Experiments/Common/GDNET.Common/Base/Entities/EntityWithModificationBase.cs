using System;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with with CreMod
    /// </summary>
    public abstract class EntityWithModificationBase<TId> : EntityWithActiveBase<TId>, IEntityWithModification<TId>
    {
        public EntityWithModificationBase() { }

        public EntityWithModificationBase(EntityWithModificationBase<TId> entity)
            : base(entity)
        {
            this.CreatedAt = entity.CreatedAt;
            this.CreatedBy = entity.CreatedBy;
            this.LastModifiedAt = entity.LastModifiedAt;
            this.LastModifiedBy = entity.LastModifiedBy;
        }

        #region IEntityCreMod Members

        public virtual string CreatedBy
        {
            get;
            set;
        }

        public virtual DateTime CreatedAt
        {
            get;
            set;
        }

        public virtual string LastModifiedBy
        {
            get;
            set;
        }

        public virtual DateTime? LastModifiedAt
        {
            get;
            set;
        }

        #endregion
    }
}
