using System.Collections.Generic;
using System.Linq;
using GDNET.Common.Base.Entities;
using GDNET.Common.Base.Meta;
using GDNET.Common.DesignByContract;
using GDNET.NHibernate.SessionManagers;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace GDNET.NHibernate.Repositories
{
    public abstract class AbstractRepositoryWithActive<TEntity, TId> : AbstractRepository<TEntity, TId> where TEntity : EntityWithActive<TId>
    {
        public AbstractRepositoryWithActive(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        /// <summary>
        /// If the entity exists, but is inactive, return default value of type
        /// </summary>
        public override TEntity GetById(TId id)
        {
            TEntity result = base.GetById(id);
            if (result.IsActive)
            {
                return result;
            }

            return default(TEntity);
        }

        public override IList<TEntity> FindByProperties(string[] properties, object[] values)
        {
            var listOfProperties = properties.ToList();
            var listOfValues = values.ToList();

            if (!listOfProperties.Contains(EntityMetaWithActive.IsActive))
            {
                listOfProperties.Add(EntityMetaWithActive.IsActive);
                listOfValues.Add(true);
            }

            return base.FindByProperties(listOfProperties.ToArray(), listOfValues.ToArray());
        }

        public override IList<TEntity> FindByProperties(string[] properties, object[] values, int page, int pageSize)
        {
            var listOfProperties = properties.ToList();
            var listOfValues = values.ToList();

            if (!listOfProperties.Contains(EntityMetaWithActive.IsActive))
            {
                listOfProperties.Add(EntityMetaWithActive.IsActive);
                listOfValues.Add(true);
            }

            return base.FindByProperties(listOfProperties.ToArray(), listOfValues.ToArray(), page, pageSize);
        }

        public override IList<TEntity> FindByProperty(string property, object value, int page, int pageSize)
        {
            var listOfProperties = new string[] { property, EntityMetaWithActive.IsActive };
            var listOfValues = new object[] { value, true };

            return base.FindByProperties(listOfProperties, listOfValues, page, pageSize);
        }

        public override IList<TEntity> FindByProperty(string property, object[] values)
        {
            ThrowException.ArgumentExceptionIfNullOrEmpty(property, "property", "You must specify a valid property.");

            var criteria = this.sessionStrategy.Session.CreateCriteria(typeof(TEntity)).Add(Expression.In(property, values)).SetCacheable(true);
            criteria = criteria.Add(Expression.Eq(EntityMetaWithActive.IsActive, true));
            return criteria.List<TEntity>();
        }

        public override IList<TEntity> FindByProperty(string property, object value, string orderByProperty, bool isAsc, int page, int pageSize)
        {
            var listOfProperties = new string[] { property, EntityMetaWithActive.IsActive };
            var listOfValues = new object[] { value, true };

            return base.FindByProperty(property, value, orderByProperty, isAsc, page, pageSize);
        }

        public override IList<TEntity> GetAll(int page, int pageSize)
        {
            return this.FindByProperty(EntityMetaWithActive.IsActive, true, page, pageSize);
        }

        public override IList<TEntity> GetAll(int page, int pageSize, out int totalRows)
        {
            var query = this.sessionStrategy.Session.Query<TEntity>().Where(x => x.IsActive).Cacheable();
            totalRows = query.Count();

            return this.GetAll(page, pageSize);
        }
    }
}
