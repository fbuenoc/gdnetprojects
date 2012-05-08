using System.Collections.Generic;
using GDNET.Common.Base.Entities;

namespace GDNET.Common.Data
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        ISpecificationBase<TEntity, TId> Specification
        {
            get;
            set;
        }

        /// <summary>
        /// Try to load an entity, it's not query to data store if we don't access file other than its id.
        /// </summary>
        TEntity LoadById(TId id);
        /// <summary>
        /// Gets entity from data store by its id.
        /// </summary>
        TEntity GetById(TId id);

        /// <summary>
        /// Gets all entities (of TEntity type) from data store.
        /// </summary>
        IList<TEntity> GetAll();
        /// <summary>
        /// Gets all entities (of TEntity type) from data store. We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        /// <param name="totalRows">Total rows by request</param>
        IList<TEntity> GetAll(int page, int pageSize);
        IList<TEntity> GetAll(int page, int pageSize, out int totalRows);

        IList<TEntity> FindByProperties(string[] properties, object[] values);
        IList<TEntity> FindByProperties(string[] properties, object[] values, int page, int pageSize);

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
        IList<TEntity> FindByProperty(string property, object value, int page, int pageSize);

        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        IList<TEntity> FindByProperty(string property, object value, string orderByProperty);
        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        IList<TEntity> FindByProperty(string property, object value, string orderByProperty, bool isAsc);
        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        IList<TEntity> FindByProperty(string property, object value, string orderByProperty, int page, int pageSize);
        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        IList<TEntity> FindByProperty(string property, object value, string orderByProperty, bool isAsc, int page, int pageSize);

        /// <summary>
        /// Save an entity to data store.
        /// </summary>
        bool Save(TEntity entity);
        /// <summary>
        /// Save many entities to data store.
        /// </summary>
        bool Save(IList<TEntity> entities);

        /// <summary>
        /// Update an entity to data store.
        /// </summary>
        bool Update(TEntity entity);
        /// <summary>
        /// Update many entities to data store.
        /// </summary>
        bool Update(IList<TEntity> entities);

        /// <summary>
        /// Delete entity from data store by its id.
        /// </summary>
        bool Delete(TId id);
        /// <summary>
        /// Delete entity from data store.
        /// </summary>
        bool Delete(TEntity entity);

        /// <summary>
        /// Delete all entities of a type from data store.
        /// </summary>
        int DeleteAll();
    }
}
