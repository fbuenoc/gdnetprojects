using GDNET.Common.DesignByContract;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id property
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public EntityBase() { }

        public EntityBase(IEntityBase<TId> entity)
        {
            Throw.ArgumentNullException(entity, "entity", "Invalid entity.");

            this.Id = entity.Id;
        }

        #region IEntity<TId> Members

        public virtual TId Id
        {
            get;
            set;
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
