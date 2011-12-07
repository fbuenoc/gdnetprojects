using GDNET.Common.Base.Entities;

namespace WebFramework.Modeles.Framework.Common
{
    public abstract class ModelActiveBase<TEntity, TId> : EntityActiveBase<TId> where TEntity : EntityActiveBase<TId>
    {
        protected TEntity Entity
        {
            get;
            private set;
        }

        public ModelActiveBase()
            : base()
        {
        }

        public ModelActiveBase(TEntity entity)
            : base(entity)
        {
            this.Entity = entity;
        }
    }
}
