using GDNET.Common.Base.Entities;

namespace WebFramework.Common.Framework.Base
{
    public abstract class ModelWithActiveBase<TEntity, TId> : ModelBase<TEntity, TId>, IModel<TId>
        where TEntity : EntityWithActive<TId>
    {
        public bool IsActive
        {
            get;
            set;
        }

        #region Ctors

        public ModelWithActiveBase()
            : base()
        {
        }

        public ModelWithActiveBase(TEntity entity)
            : base(entity)
        {
            this.IsActive = entity.IsActive;
        }

        #endregion

    }
}
