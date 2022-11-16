using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Interface for getting all entities.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// /// <typeparam name="TEntity">Entity type.</typeparam>
    public interface IGettable<TEntity>
    {
        /// <summary>
        /// Returns all entities.
        /// </summary>
        Task<IEnumerable<TEntity>> GetAsync();
        /// <summary>
        /// Returns all entities that match the given filter.
        /// </summary>
        /// <param name="filter">Search criteria.</param>
        Task<IEnumerable<TEntity>> GetByCriteriaAsync(Expression<Func<TEntity, bool>> filter = null);

    }
}