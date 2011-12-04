using GDNET.Common.DesignByContract;

namespace GDNET.Common.Base.Entities
{
    /// <summary>
    /// Entity with Id property
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class EntityActiveBase<TId> : EntityBase<TId>, IEntityActiveBase<TId>
    {
        public EntityActiveBase()
            : base()
        {
        }

        public EntityActiveBase(IEntityActiveBase<TId> entity)
            : base(entity)
        {
            this.IsActive = entity.IsActive;
        }

        #region IEntity<TId> Members

        public virtual bool IsActive
        {
            get;
            set;
        }

        #endregion
    }
}
