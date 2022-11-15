using System;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Interface for getting entities by id.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    public interface IGettableById<TDto>
    {
        /// <summary>
        /// Interface method for getting entities by id.
        /// </summary>
        /// <param name="id">Identifier.</param>
        Task<TDto> GetByIdAsync(int id);
    }
}
