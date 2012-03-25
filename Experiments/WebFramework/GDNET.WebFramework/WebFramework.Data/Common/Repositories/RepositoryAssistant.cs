using GDNET.Common.Base.Entities;
using GDNET.Common.Data;
using GDNET.NHibernate.SessionManagers;

namespace WebFramework.Data.Common.Repositories
{
    public static class RepositoryAssistant
    {
        public static IRepositoryBase<TEntity, TId> Get<TEntity, TId>(ISessionStrategy sessionStrategy)
            where TEntity : EntityWithActiveBase<TId>
        {
            return new GenericRepository<TEntity, TId>(sessionStrategy);
        }
    }
}
