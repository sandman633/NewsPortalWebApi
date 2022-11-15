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
    public interface IGettable<TDto, TEntity>
    {
        /// <summary>
        /// Returns all entities.
        /// </summary>
        Task<IEnumerable<TDto>> GetAsync();
        /// <summary>
        /// Returns all entities that match the given filter.
        /// </summary>
        /// <param name="filter">Search criteria.</param>
        Task<IEnumerable<TDto>> GetByCriteriaAsync(Expression<Func<TEntity, bool>> filter = null);

    }
}