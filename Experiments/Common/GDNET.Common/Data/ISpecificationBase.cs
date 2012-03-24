using GDNET.Common.Base.Entities;

namespace GDNET.Common.Data
{
    public interface ISpecificationBase<TEntity, TId> where TEntity : IEntityWithActiveBase<TId>
    {
        bool OnGetting(TId id);
        bool OnGotten(TEntity entity);

        bool OnSaving(TEntity entity);
        bool OnSaved(TEntity entity);

        bool OnDeleting(TEntity entity);
        bool OnDeleted(TEntity entity);

        bool OnUpdating(TEntity entity);
        bool OnUpdated(TEntity entity);
    }
}
