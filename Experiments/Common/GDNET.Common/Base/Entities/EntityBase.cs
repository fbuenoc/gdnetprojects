using GDNET.Common.DesignByContract;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id property
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        #region Ctors

        public EntityBase()
        {
            this.Id = default(TId);
        }

        public EntityBase(IEntityBase<TId> entity)
        {
            ThrowException.ArgumentNullException(entity, "entity", "Invalid entity.");

            this.Id = entity.Id;
        }

        #endregion

        #region IEntity<TId> Members

        public virtual TId Id
        {
            get;
            protected set;
        }

        /// <summary>
        /// Format of this property is TypeName_Id (Of this instance), without any space
        /// </summary>
        public virtual string Signature
        {
            get
            {
                var id = (this.Id == null) ? string.Empty : this.Id.ToString();
                return string.Format("{0}_{1}", this.GetType().Name, id);
            }
        }

        #endregion
    }
}
