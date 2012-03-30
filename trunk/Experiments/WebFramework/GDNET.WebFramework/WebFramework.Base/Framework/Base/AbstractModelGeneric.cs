using GDNET.Common.Base.Entities;

namespace WebFramework.Common.Framework.Base
{
    public abstract class AbstractModelGeneric<TEntity, TId> : AbstractModel, IViewModel<TId>
        where TEntity : EntityBase<TId>
    {
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

        #region Ctors

        public AbstractModelGeneric()
            : base()
        {
        }

        public AbstractModelGeneric(TEntity entity)
            : base()
        {
            this.Id = entity.Id;
            this.Entity = entity;
        }

        #endregion

    }
}
