using GDNET.Common.Base.Entities;

namespace WebFramework.Common.Framework.Base
{
    public abstract class AbstractModelGenericWithActive<TEntity, TId> : AbstractModelGeneric<TEntity, TId>, IViewModel<TId>
        where TEntity : EntityWithActive<TId>
    {
        public bool IsActive
        {
            get;
            set;
        }

        #region Ctors

        public AbstractModelGenericWithActive()
            : base()
        {
        }

        public AbstractModelGenericWithActive(TEntity entity)
            : base(entity)
        {
            this.IsActive = entity.IsActive;
        }

        #endregion

    }
}
