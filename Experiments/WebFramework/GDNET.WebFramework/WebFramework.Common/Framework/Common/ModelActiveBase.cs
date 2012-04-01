using GDNET.Common.Base.Entities;

namespace WebFramework.Modeles.Framework.Common
{
    public abstract class ModelActiveBase<TEntity, TId> : EntityWithActiveBase<TId>, IEntityModeleBase<TId> where TEntity : EntityWithActiveBase<TId>
    {
        protected TEntity Entity
        {
            get;
            private set;
        }

        #region IEntityModeleBase Members

        public new TId Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        #endregion

        #region Ctors

        public ModelActiveBase()
            : base()
        {
        }

        public ModelActiveBase(TEntity entity)
            : base(entity)
        {
            this.Entity = entity;
        }

        #endregion
    }
}
