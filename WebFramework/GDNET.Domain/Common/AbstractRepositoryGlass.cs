namespace GDNET.Domain.Common
{
    public class AbstractRepositoryGlass<TEntity, TId> : IRepositoryGlass<TEntity>
    {
        public virtual void ValidateOnCreation(TEntity entity) { }

        public virtual void ValidateOnModification(TEntity entity) { }
    }
}
