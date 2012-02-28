using GDNET.Common.Base.Entities;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;

namespace WebFrameworkData.Common.Repositories
{
    public sealed class GenericRepository<TEntity, TId> : AbstractRepository<TEntity, TId>
       where TEntity : EntityBase<TId>
    {
        public GenericRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }
    }
}
