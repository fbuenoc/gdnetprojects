using GDNET.Common.Base.Entities;

namespace WebFramework.Common.Framework.Base
{
    public abstract class ModelEntityWithActiveBase<TEntity, TId> : ModelEntityBase<TEntity, TId>
        where TEntity : EntityWithActive<TId>
    {
        protected bool filterActive = true;

        public bool IsActive
        {
            get;
            set;
        }

        #region Ctors

        public ModelEntityWithActiveBase()
            : base()
        {
        }

        public ModelEntityWithActiveBase(TEntity entity)
            : base(entity)
        {
            this.IsActive = entity.IsActive;
        }

        #endregion

    }
}
