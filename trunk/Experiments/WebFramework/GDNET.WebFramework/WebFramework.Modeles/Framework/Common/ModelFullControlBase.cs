using GDNET.Common.Base.Entities;

namespace WebFramework.Modeles.Framework.Common
{
    public abstract class ModelFullControlBase<TEntity, TId> : ModelActiveBase<TEntity, TId> where TEntity : EntityFullControlBase<TId>
    {
        public ModelFullControlBase() : base() { }

        public ModelFullControlBase(TEntity entity) : base(entity) { }
    }
}
