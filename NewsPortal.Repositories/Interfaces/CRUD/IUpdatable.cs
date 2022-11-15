using System.Threading.Tasks;

namespace Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Interface for updating entity.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    public interface IUpdatable<TDto>
    {
        /// <summary>
        /// Interface method for updating entity.
        /// </summary>
        /// <param name="dto">DTO.</param>
        Task<TDto> UpdateAsync(TDto dto);
    }
}