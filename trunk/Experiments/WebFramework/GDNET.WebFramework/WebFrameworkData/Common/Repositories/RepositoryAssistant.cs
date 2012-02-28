using GDNET.Common.Base.Entities;
using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;

namespace WebFrameworkData.Common.Repositories
{
    public static class RepositoryAssistant
    {
        public static IRepositoryBase<TEntity, TId> Get<TEntity, TId>(ISessionStrategy sessionStrategy)
            where TEntity : EntityBase<TId>
        {
            return new GenericRepository<TEntity, TId>(sessionStrategy);
        }
    }
}
