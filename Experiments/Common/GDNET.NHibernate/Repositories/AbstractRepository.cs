using System.Collections.Generic;
using System.Linq;
using GDNET.Common.Base.Entities;
using GDNET.Common.Data;
using GDNET.Common.DesignByContract;
using GDNET.NHibernate.SessionManagers;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace GDNET.NHibernate.Repositories
{
    /// <summary>
    /// Base Repository for working with NHibernate
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public abstract class AbstractRepository<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        protected ISessionStrategy sessionStrategy = null;

        #region Ctors

        public AbstractRepository(ISessionStrategy sessionStrategy)
        {
            ThrowException.ArgumentNullException(sessionStrategy, "sessionStrategy", "Session strategy must be specified a valid instance.");
            this.sessionStrategy = sessionStrategy;
        }

        #endregion

        public ISpecificationBase<TEntity, TId> Specification
        {
            get;
            set;
        }

        #region IRepositoryBase<TEntity,TId> Members

        public TEntity LoadById(TId id)
        {
            return this.sessionStrategy.Session.Load<TEntity>(id);
        }

        public TEntity GetById(TId id)
        {
            if (this.Specification != null)
            {
                string message = string.Format("Can not get value for item '{0}' of type '{1}'", id.ToString(), typeof(TEntity).Name);
                ThrowException.InvalidOperationExceptionIfFalse(this.Specification.OnGetting(id), message);
            }

            TEntity result = this.sessionStrategy.Session.Get<TEntity>(id);

            if (this.Specification != null)
            {
                string message = string.Format("Can not get value for item '{0}' of type '{1}'", id.ToString(), typeof(TEntity).Name);
                ThrowException.InvalidOperationExceptionIfFalse(this.Specification.OnGotten(result), message);
            }

            return result;
        }

        #region GetAll Methods

        /// <summary>
        /// Gets all entities (of TEntity type) from data store.
        /// </summary>
        /// <returns></returns>
        public IList<TEntity> GetAll()
        {
            return this.GetAll(0, 0);
        }

        /// <summary>
        /// Gets all entities (of TEntity type) from data store. We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        /// <returns></returns>
        public IList<TEntity> GetAll(int page, int pageSize)
        {
            var query = this.sessionStrategy.Session.Query<TEntity>().Cacheable();
            if (!(page == 0 && pageSize == 0))
            {
                query = query.Skip(page * pageSize).Take(pageSize);
            }
            return query.ToList();
        }

        public IList<TEntity> GetAll(int page, int pageSize, out int totalRows)
        {
            var query = this.sessionStrategy.Session.Query<TEntity>().Cacheable();
            totalRows = query.Count();

            if (!(page == 0 && pageSize == 0))
            {
                query = query.Skip(page * pageSize).Take(pageSize);
            }
            return query.ToList();
        }

        #endregion

        #region FindByProperty Methods

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        public IList<TEntity> FindByProperty(string property, object value)
        {
            return this.FindByProperty(property, value, 0, 0);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and values of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="values">The value of the property.</param>
        public IList<TEntity> FindByProperty(string property, object[] values)
        {
            ThrowException.ArgumentExceptionIfNullOrEmpty(property, "property", "You must specify a valid property.");

            var criteria = this.sessionStrategy.Session.CreateCriteria(typeof(TEntity)).Add(Expression.In(property, values)).SetCacheable(true);
            return criteria.List<TEntity>();
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        public IList<TEntity> FindByProperty(string property, object value, int page, int pageSize)
        {
            ThrowException.ArgumentExceptionIfNullOrEmpty(property, "property", "You must specify a valid property.");

            var criteria = this.sessionStrategy.Session.CreateCriteria(typeof(TEntity)).Add(Expression.Eq(property, value));
            if (!(page == 0 && pageSize == 0))
            {
                criteria = criteria.SetFirstResult(page * pageSize).SetMaxResults(pageSize);
            }

            return criteria.SetCacheable(true).List<TEntity>();
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        public IList<TEntity> FindByProperty(string property, object value, string orderByProperty)
        {
            return this.FindByProperty(property, value, orderByProperty, true, 0, 0);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        public IList<TEntity> FindByProperty(string property, object value, string orderByProperty, bool isAsc)
        {
            return this.FindByProperty(property, value, orderByProperty, isAsc, 0, 0);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        public IList<TEntity> FindByProperty(string property, object value, string orderByProperty, int page, int pageSize)
        {
            return this.FindByProperty(property, value, orderByProperty, true, 0, 0);
        }

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        public IList<TEntity> FindByProperty(string property, object value, string orderByProperty, bool isAsc, int page, int pageSize)
        {
            var orderBy = new Order(orderByProperty, isAsc);
            var criteria = this.sessionStrategy.Session.CreateCriteria(typeof(TEntity)).Add(Expression.Eq(property, value));
            criteria = criteria.AddOrder(orderBy);

            if ((page != 0) || (pageSize != 0))
            {
                criteria = criteria.SetFirstResult(page * pageSize).SetMaxResults(pageSize);
            }

            return criteria.SetCacheable(true).List<TEntity>();
        }

        #endregion

        public virtual bool Save(TEntity entity)
        {
            ThrowException.ArgumentNullException(entity, "entity", "Entity must be valid to be saved.");

            if ((this.Specification != null) && !this.Specification.OnSaving(entity))
            {
                return false;
            }

            // Saving entity
            this.sessionStrategy.Session.SaveOrUpdate(entity);

            if ((this.Specification != null) && !this.Specification.OnSaved(entity))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Save many entities to data store.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual bool Save(IList<TEntity> entities)
        {
            ThrowException.ArgumentNullException(entities, "entities", "List of entities must be valid to be saved.");

            foreach (var e in entities)
            {
                if (!this.Save(e))
                {
                    return false;
                }
            }

            return true;
        }

        public virtual bool Update(TEntity entity)
        {
            ThrowException.ArgumentNullException(entity, "entity", "Entity must be valid to be updated.");

            if ((this.Specification != null) && !this.Specification.OnUpdating(entity))
            {
                return false;
            }

            this.sessionStrategy.Session.SaveOrUpdate(entity);

            if ((this.Specification != null) && !this.Specification.OnUpdated(entity))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Update many entities to data store.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual bool Update(IList<TEntity> entities)
        {
            ThrowException.ArgumentNullException(entities, "entities", "List of entities must be valid to be updated.");

            foreach (var e in entities)
            {
                if (!this.Update(e))
                {
                    return false;
                }
            }

            return true;
        }

        public virtual bool Delete(TId id)
        {
            return this.Delete(this.sessionStrategy.Session.Load<TEntity>(id));
        }

        public virtual bool Delete(TEntity entity)
        {
            ThrowException.ArgumentNullException(entity, "entity", "Entity must be valid to be deleted.");

            if ((this.Specification != null) && !this.Specification.OnDeleting(entity))
            {
                return false;
            }

            this.sessionStrategy.Session.Delete(entity);

            if ((this.Specification != null) && !this.Specification.OnDeleted(entity))
            {
                return false;
            }

            return true;
        }

        public int DeleteAll()
        {
            string hql = "delete " + typeof(TEntity).Name;
            return this.sessionStrategy.Session.CreateQuery(hql).ExecuteUpdate();
        }

        #endregion

    }
}
