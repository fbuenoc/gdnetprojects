using System.Collections.Generic;
using NHibernate.Criterion;

using GDNET.Common.Data;

namespace GDNET.Extensions.NHibernateImpl.Data
{
    public interface INHRepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
    {
        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        IList<TEntity> FindByProperty(string property, object value, Order orderBy);
        /// <summary>
        /// Retrieves a collection of entities based on the name and value of a property.
        /// We ignore paging condition if page & pageSize are equal 0.
        /// </summary>
        /// <typeparam name="TEntity">The type of entities to retrieve.</typeparam>
        /// <param name="property">The name of the property; should be a member of type TEntity.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="page">Zero base page</param>
        /// <param name="pageSize">Number of item per each page</param>
        IList<TEntity> FindByProperty(string property, object value, Order orderBy, uint page, uint pageSize);
    }
}
