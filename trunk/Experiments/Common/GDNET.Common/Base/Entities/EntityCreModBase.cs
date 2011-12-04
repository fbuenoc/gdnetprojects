using System;
using GDNET.Common.DesignByContract;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with with CreMod
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class EntityCreModBase<TId> : EntityActiveBase<TId>, IEntityCreMod<TId>
    {
        public EntityCreModBase() { }

        public EntityCreModBase(EntityCreModBase<TId> entity)
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
