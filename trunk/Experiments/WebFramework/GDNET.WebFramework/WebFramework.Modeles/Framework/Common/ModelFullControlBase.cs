using GDNET.Common.Base.Entities;

namespace WebFramework.Modeles.Framework.Common
{
    public abstract class ModelFullControlBase<TEntity, TId> : EntityFullControlBase<TId> where TEntity : EntityFullControlBase<TId>
    {
        protected TEntity Entity
        {
            get;
            private set;
        }

        public ModelFullControlBase()
            : base()
        {
        }

        public ModelFullControlBase(TEntity entity)
            : base(entity)
        {
            this.Entity = entity;
        }
    }
}
