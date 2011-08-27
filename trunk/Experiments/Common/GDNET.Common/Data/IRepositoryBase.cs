using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Common.Data
{
    public interface IRepositoryBase<TEntity, TId>
    {
        /// <summary>
        /// Begins a transaction.
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// Commits a transaction.
        /// </summary>
        void Commit();
        /// <summary>
        /// Rolls back a transaction.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Try to load an entity, it's not query to data store if we don't access file other than its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity LoadById(TId id);
        /// <summary>
        /// Gets entity from data store by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(TId id);

        /// <summary>
        /// Gets all entities (of TEntity type) from data store.
        /// </summary>
        /// <returns></returns>
        IList<TEntity> GetAll();
        /// <summary>
        /// Gets all entities (of TEntity type) from data store. We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        /// <returns></returns>
        IList<TEntity> GetAll(uint page, uint pageSize);

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        IList<TEntity> FindByProperty(string property, object value);
        /// <summary>
        /// Retrieves a collection of entities based on the name and values of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="values">The value of the property.</param>
        IList<TEntity> FindByProperty(string property, object[] values);
        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        IList<TEntity> FindByProperty(string property, object value, uint page, uint pageSize);

        /// <summary>
        /// Save or update entity to data store.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity SaveOrUpdate(TEntity entity);
        /// <summary>
        /// Save or update many entities to data store.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IList<TEntity> SaveOrUpdate(IList<TEntity> entities);

        /// <summary>
        /// Delete entity from data store by its id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(TId id);
        /// <summary>
        /// Delete entity from data store.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}
