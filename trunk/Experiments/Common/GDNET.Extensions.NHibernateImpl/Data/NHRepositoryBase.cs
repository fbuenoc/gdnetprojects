using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

using GDNET.Common.Data;
using GDNET.Common.DesignByContract;
using GDNET.Common.Domain;
using GDNET.Extensions.NHibernateImpl.Data;

namespace GoogleCode.Core.Data
{
    /// <summary>
    /// Base Repository for working with NHibernate
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public abstract class NHRepositoryBase<TEntity, TId> : IDisposable, INHRepositoryBase<TEntity, TId> where TEntity : DomainBase<TId>
    {
        protected ISession session = null;
        protected ITransaction transaction = null;

        public NHRepositoryBase(ISession session)
        {
            Throw.ArgumentNullException(session, "session", "Session must be specified a valid instance.");
            this.session = session;
        }

        #region IDisposable Members

        /// <summary>
        /// Disposes of this instance of the Repository.
        /// </summary>
        /// <param name="isDisposing">Flag that tells the .NET runtime if this class is disposing.</param>
        /// <remarks>This method kills the existing NHibernate session, transaction, and interceptor.</remarks>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (this.transaction != null)
                {
                    this.transaction.Dispose();
                    this.transaction = null;
                }

                if (this.session != null)
                {
                    this.session.Dispose();
                    this.session = null;
                }
            }
        }

        /// <summary>
        /// Disposes of this instance of the Repository.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IRepositoryBase<TEntity,TId> Members

        /// <summary>
        /// Begins a NHibernate transaction.
        /// </summary>
        public void BeginTransaction()
        {
            if (this.transaction == null)
            {
                this.transaction = this.session.BeginTransaction();
            }
        }

        /// <summary>
        /// Commits an NHibernate transaction.
        /// </summary>
        public void Commit()
        {
            Throw.InvalidOperationExceptionIfNull(this.transaction, "You must begin transaction before calling Commit.");

            this.transaction.Commit();
            this.transaction = null;
        }

        /// <summary>
        /// Rolls back an NHibernate transaction.
        /// </summary>
        public void Rollback()
        {
            Throw.InvalidOperationExceptionIfNull(this.transaction, "You must begin transaction before calling Rollback.");

            this.transaction.Rollback();
            this.transaction = null;
        }

        public TEntity LoadById(TId id)
        {
            return this.session.Load<TEntity>(id);
        }

        public TEntity GetById(TId id)
        {
            return this.session.Get<TEntity>(id);
        }

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
        public IList<TEntity> GetAll(uint page, uint pageSize)
        {
            if (page == 0 && pageSize == 0)
            {
                return this.session.Query<TEntity>().ToList();
            }
            else
            {
                return this.session.Query<TEntity>().Skip((int)(page * pageSize)).Take((int)pageSize).ToList();
            }
        }

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
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        public IList<TEntity> FindByProperty(string property, object value, uint page, uint pageSize)
        {
            Throw.ArgumentExceptionIfNullOrEmpty(property, "property", "You must specify a valid property.");

            var criteria = this.session.CreateCriteria(typeof(TEntity)).Add(Expression.Eq(property, value));
            if (!(page == 0 && pageSize == 0))
            {
                criteria = criteria.SetFirstResult((int)(page * pageSize)).SetMaxResults((int)pageSize);
            }

            return criteria.List<TEntity>();
        }

        public TEntity SaveOrUpdate(TEntity entity)
        {
            Throw.ArgumentNullException(entity, "entity", "Entity must be valid to be saved.");

            this.session.SaveOrUpdate(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Throw.ArgumentNullException(entity, "entity", "Entity must be valid to be deleted.");

            this.session.Delete(entity);
        }

        #endregion

        #region INHRepositoryBase<TEntity,TId> Members

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        public IList<TEntity> FindByProperty(string property, object value, Order orderBy)
        {
            return this.FindByProperty(property, value, orderBy, 0, 0);
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
        public IList<TEntity> FindByProperty(string property, object value, Order orderBy, uint page, uint pageSize)
        {
            var criteria = this.session.CreateCriteria(typeof(TEntity)).Add(Expression.Eq(property, value));
            criteria = criteria.AddOrder(orderBy);

            if (!(page == 0 && pageSize == 0))
            {
                criteria = criteria.SetFirstResult((int)(page * pageSize)).SetMaxResults((int)pageSize);
            }

            return criteria.List<TEntity>();
        }

        #endregion
    }
}
