using GDNET.Common.Base.Entities;

namespace WebFramework.Common.Framework.Base
{
    public abstract class ModelBase<TEntity, TId> : ModelBase, IModel<TId>
        where TEntity : EntityBase<TId>
    {
        #region Properties

        protected TEntity Entity
        {
            get;
            private set;
        }

        public TId Id
        {
            get
            {
                if (base.EntityId != null)
                {
                    return (TId)base.EntityId;
                }
                return default(TId);
            }
            set { base.EntityId = value; }
        }

        #endregion

        #region Ctors

        public ModelBase()
            : base()
        {
        }

        public ModelBase(TEntity entity)
            : base()
        {
            this.Id = entity.Id;
            this.Entity = entity;
        }

        #endregion

    }
}
