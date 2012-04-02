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
                if (base.id != null)
                {
                    return (TId)base.id;
                }
                return default(TId);
            }
            set { base.id = value; }
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
