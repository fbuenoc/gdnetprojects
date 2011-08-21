using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Common.Data
{
    public interface IRepositoryBase<TEntity, TId>
    {
        /// <summary>
        /// Begins a NHibernate transaction.
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// Commits an NHibernate transaction.
        /// </summary>
        void Commit();
        /// <summary>
        /// Rolls back an NHibernate transaction.
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
        /// Save or update entity to data store.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity SaveOrUpdate(TEntity entity);
        /// <summary>
        /// Delete entity from data store.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}
