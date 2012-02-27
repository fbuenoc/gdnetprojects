using GDNET.Common.Base.Entities;
using GDNET.Common.Data;

namespace WebFrameworkDomain.Base
{
    public abstract class AbstractSpecification<TEntity, TId> : ISpecificationBase<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        public virtual bool OnGetting(TId id)
        {
            return true;
        }
        public virtual bool OnGotten(TEntity entity)
        {
            return true;
        }

        public virtual bool OnSaving(TEntity entity)
        {
            return true;
        }
        public virtual bool OnSaved(TEntity entity)
        {
            return true;
        }

        public virtual bool OnDeleting(TEntity entity)
        {
            return true;
        }
        public virtual bool OnDeleted(TEntity entity)
        {
            return true;
        }

        public virtual bool OnUpdating(TEntity entity)
        {
            return true;
        }
        public virtual bool OnUpdated(TEntity entity)
        {
            return true;
        }
    }
}
